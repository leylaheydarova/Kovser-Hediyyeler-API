using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Orders;
using KovserHediyyeler.Application.DTOs.Orders.OrderDetails;
using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Application.Repositories.Orders;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderDetailReadRepository _orderDetailReadRepository;
        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;
        readonly IOrderPaymentReadRepository _orderPaymentReadRepository;
        readonly IOrderPaymentWriteRepository _orderPaymentWriteRepository;
        readonly IShippingReadRepository _shippingReadRepository;
        readonly IShippingWriteRepository _shippingWriteRepository;
        readonly IBasketItemReadRepository _basketItemReadRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly UserManager<WebUser> _userManager;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IOrderDetailReadRepository orderDetailReadRepository, IOrderDetailWriteRepository orderDetailWriteRepository, IOrderPaymentReadRepository orderPaymentReadRepository, IOrderPaymentWriteRepository orderPaymentWriteRepository, IShippingReadRepository shippingReadRepository, IShippingWriteRepository shippingWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, UserManager<WebUser> userManager, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderDetailReadRepository = orderDetailReadRepository;
            _orderDetailWriteRepository = orderDetailWriteRepository;
            _orderPaymentReadRepository = orderPaymentReadRepository;
            _orderPaymentWriteRepository = orderPaymentWriteRepository;
            _shippingReadRepository = shippingReadRepository;
            _shippingWriteRepository = shippingWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _userManager = userManager;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        async Task<WebUser> GetUserAsync(string userId)
        {
            var webUser = await _userManager.FindByIdAsync(userId);
            if (webUser == null) throw new NotFoundException("istifadəçi");
            return webUser;
        }
        string GenerateTrackingNumber(string prefix)
        {
            var date = DateTime.Now.AddHours(4);
            var trackingString = $"{prefix}{date}";
            return trackingString;
        } //todo: datetime formati daha oxunaqlidir, onu sadece yanyana reqemler sekline cevir

        public async Task<bool> CreateOrderAsync(string customerId, OrderDto orderDto)
        {
            using var transaction = await _orderWriteRepository.BeginTransactionAsync();
            bool isPaid;
            try
            {
                var webUser = await GetUserAsync(customerId);
                var basket = await _basketReadRepository.GetWhereAsync(b => b.CustomerID == webUser.Id && !b.isDeleted, true, "BasketItems", "Customer");
                if (basket == null) throw new NotFoundException("səbət");
                var items = _basketItemReadRepository.GetAllWhere(i => i.BasketID == basket.ID && i.isSelected && !i.isDeleted, true, "Product");
                if (items == null) throw new FailException("Səbət boşdur!");
                List<OrderDetailCreateDto> detailDtos = new List<OrderDetailCreateDto>();
                foreach (var item in items)
                {
                    var detailDto = new OrderDetailCreateDto
                    {
                        Quantity = item.ProductCount,
                        DiscountedPrice = (item.Product.DiscountedPrice * item.ProductCount),
                        Price = (item.Product.Price * item.ProductCount),
                        ProductID = item.ProductID,
                        SelectedColor = item.SelectedColor,
                        SelectedSize = item.SelectedSize
                    };
                    detailDtos.Add(detailDto);
                }

                List<Guid> productIds = new List<Guid>();

                foreach (var detail in detailDtos)
                {
                    var productId = detail.ProductID;
                    productIds.Add(productId);
                }

                List<Product> products = new List<Product>();
                foreach (var id in productIds)
                {
                    var product = await _productReadRepository.GetWhereAsync(p => p.ID == id && !p.isDeleted, true);
                    if (product == null) throw new NotFoundException("məhsul");
                    products.Add(product);
                }

                var order = new Order
                {
                    ID = Guid.NewGuid(),
                    OrderTrackingNumber = GenerateTrackingNumber("ORD"),
                    CustomerID = webUser.Id,
                    TotalPrice = detailDtos.Sum(d => d.Price),
                    DiscountedPrice = detailDtos.Sum(d => d.DiscountedPrice),
                    SavingAmount = (detailDtos.Sum(d => d.Price) - detailDtos.Sum(d => d.DiscountedPrice)),
                    OrderDate = DateTime.Now.AddHours(4),
                    RequiredDate = DateTime.Now.AddHours(4).AddDays(25),
                    OrderStatus = OrderStatus.SifarişAlındı
                };

                foreach (var dto in detailDtos)
                {
                    var product = products.FirstOrDefault(p => p.ID == dto.ProductID);
                    var detail = new OrderDetail
                    {
                        ID = Guid.NewGuid(),
                        OrderID = order.ID,
                        Price = dto.DiscountedPrice,
                        ProductID = dto.ProductID,
                        SelectedColor = dto.SelectedColor,
                        SelectedSize = dto.SelectedSize
                    };
                    if (dto.Quantity > product.Stock) throw new InvalidCountException(product.Stock);
                    detail.Quantity = dto.Quantity;
                    product.Stock -= detail.Quantity;
                    order.Details.Add(detail);
                    await _orderDetailWriteRepository.AddAsync(detail);
                    _productWriteRepository.Update(product);
                }
                
                order.OrderPayment = new OrderPayment
                {
                    ID = Guid.NewGuid(),
                    Currency = orderDto.Currency,
                    PaymentMethod = orderDto.PaymentMethod,
                    PaymentStatus = orderDto.PaymentStatus,
                    PaymentDate = orderDto.PaymentStatus == PaymentStatus.Paid ? DateTime.Now.AddHours(4) : null,
                    OrderID = order.ID
                };
                await _orderPaymentWriteRepository.AddAsync(order.OrderPayment);

                if (order.OrderPayment.PaymentStatus == PaymentStatus.Paid)
                {
                    order.Shipping = new Shipping
                    {
                        ID = Guid.NewGuid(),
                        OrderID = order.ID,
                        ShippingStatus = ShippingStatus.Gözləmədə,
                        ShippingType = orderDto.ShippingType,
                    };
                    await _shippingWriteRepository.AddAsync(order.Shipping);
                    await _shippingWriteRepository.SaveAsync();
                    isPaid = true;
                }
                else
                {
                    isPaid = false;
                }

                foreach (var item in items)
                {
                    basket.Count -= item.ProductCount;
                    basket.TotalPrice -= (item.Product.DiscountedPrice * item.ProductCount);
                    _basketItemWriteRepository.RemovePermanently(item);
                    _basketWriteRepository.Update(basket);
                }
                await _orderWriteRepository.AddAsync(order);
                await _orderDetailWriteRepository.SaveAsync();
                await _orderWriteRepository.SaveAsync();
                await _productWriteRepository.SaveAsync();
                //await _basketWriteRepository.SaveAsync();
                //await _basketItemWriteRepository.SaveAsync();


                await transaction.CommitAsync();
                return isPaid;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw new FailException("Sifari yaradılarkən, gözlənilməz xəta baş verdi. Zəhmət olmasa yenidən cəhd edin.");
            }
        }

        public async Task<bool> ApproveOrderPaymentAsync(string customerId, PaymentStatus status, Guid OrderId, ShippingType type)
        {
            using var transaction = await _orderWriteRepository.BeginTransactionAsync();
            try
            {
                bool result = false;
                var order = await _orderReadRepository.GetWhereAsync(o => o.ID == OrderId && !o.isDeleted, true, "OrderPayment");
                if (order == null) throw new NotFoundException("sifariş");
                var customer = await GetUserAsync(customerId);
                if (order.CustomerID == customer.Id)
                {
                    if (status == PaymentStatus.Paid)
                    {
                        order.OrderPayment.PaymentStatus = PaymentStatus.Paid;
                        order.OrderPayment.PaymentDate = DateTime.UtcNow.AddHours(4);
                        order.Shipping = new Shipping
                        {
                            ID = Guid.NewGuid(),
                            OrderID = order.ID,
                            ShippingStatus = ShippingStatus.Gözləmədə,
                            ShippingType = type,
                        };
                        await _shippingWriteRepository.AddAsync(order.Shipping);
                        await _shippingWriteRepository.SaveAsync();
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                _orderPaymentWriteRepository.Update(order.OrderPayment);
                _orderWriteRepository.Update(order);
                await _orderPaymentWriteRepository.SaveAsync();
                await _orderWriteRepository.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> CancelOrderAsync(Guid OrderId)
        {
            using var transanction = await _orderWriteRepository.BeginTransactionAsync();
            var result = false;
            try
            {
                var order = await _orderReadRepository.GetWhereAsync(o => o.ID == OrderId && !o.isDeleted, true, "OrderPayment", "Details", "Shipping");
                if (order == null) throw new NotFoundException("sifariş");
                foreach (var detail in order.Details)
                {
                    _orderDetailWriteRepository.RemovePermanently(detail);
                }
                _shippingWriteRepository.RemovePermanently(order.Shipping);
                _orderPaymentWriteRepository.RemovePermanently(order.OrderPayment);
                _orderWriteRepository.RemovePermanently(order);

                await _orderDetailWriteRepository.SaveAsync();
                await _shippingWriteRepository.SaveAsync();
                await _orderPaymentWriteRepository.SaveAsync();
                await _orderWriteRepository.SaveAsync();
                result = true;
                await transanction.CommitAsync();
                return result;
            }
            catch
            {
                await transanction.RollbackAsync();
                result = false;
                throw;
            }
        }

        public async Task ChangeShippingStatusAsync(Guid OrderId, ShippingStatus status)
        {
            var order = await _orderReadRepository.GetWhereAsync(o => o.ID == OrderId && !o.isDeleted, true, "Shipping");
            if (order == null) throw new NotFoundException("sifariş");
            order.Shipping.ShippingStatus = status;
            _shippingWriteRepository.Update(order.Shipping);
            await _shippingWriteRepository.SaveAsync();
        }

        public async Task ChangeOrderStatusAsync(Guid OrderId, OrderStatus status)
        {
            var order = await _orderReadRepository.GetWhereAsync(o => o.ID == OrderId && !o.isDeleted, true);
            if (order == null) throw new NotFoundException("sifariş");
            order.OrderStatus = status;
            _orderWriteRepository.Update(order);
            await _orderWriteRepository.SaveAsync();
        }

        public async Task<List<OrderGetAllForACustomerDto>> GetAllCustomerOrdersAsync(int page, int size, string customerId)
        {
            var customer = await GetUserAsync(customerId);
            var query = _orderReadRepository.GetAllWhere(o => o.CustomerID == customer.Id && !o.isDeleted, false, "Details.Product");
            var dtos = new List<OrderGetAllForACustomerDto>();
            dtos = await query.Skip(page * size)
                .Take(size)
                .Select(order => new OrderGetAllForACustomerDto
                {
                    Id = order.ID.ToString(),
                    OrderTrackingNumber = order.OrderTrackingNumber,
                    DiscountedPrice = order.DiscountedPrice,
                    OrderStatus = order.OrderStatus,
                    ImageNames = order.Details.Select(d => d.Product.Images.FirstOrDefault(i => i.IsMain).FileName).ToList(),
                    ImageURLs = order.Details.Select(d => d.Product.Images.FirstOrDefault(i => i.IsMain).Path).ToList()
                }).ToListAsync();
            return dtos;
        }

        public async Task<List<OrderGetAllDto>> GetAllOrdersAsync(int page, int size)
        {
            var query = _orderReadRepository.GetAllWhere(o => !o.isDeleted, false, "Customer");
            var dtos = new List<OrderGetAllDto>();
            dtos = await query.Skip(page * size)
                .Take(size)
                .Select(order => new OrderGetAllDto
                {
                    Id = order.ID.ToString(),
                    OrderTrackingNumber = order.OrderTrackingNumber,
                    DiscountedPrice = order.DiscountedPrice,
                    OrderStatus = order.OrderStatus,
                    CustomerId = order.CustomerID,
                    CustomerName = order.Customer.FullName,
                    CustomerPhone = order.Customer.PhoneNumber
                }).ToListAsync();
            return dtos;
        }

        public async Task<List<OrderDetailGetAllDto>> GetAllOrderDetailsAsync(Guid orderId)
        {
            var order = await _orderReadRepository.GetWhereAsync(o => o.ID == orderId && !o.isDeleted, false, "Details.Product");
            if (order == null) throw new NotFoundException("sifariş");
            var details = order.Details;
            if (details == null) throw new NotFoundException("sifarişin detalı");
            var dtos = new List<OrderDetailGetAllDto>();
            dtos = details.Select(detail => new OrderDetailGetAllDto
            {
                Id = detail.ID.ToString(),
                Quantity = detail.Quantity,
                Price = detail.Price,
                ProductId = detail.ProductID.ToString(),
                ProductName = detail.Product.Name
            }).ToList();
            return dtos;
        }

        public async Task<OrderGetSingleDto> GetSingleOrderAsync(Guid orderId)
        {
            var order = await _orderReadRepository.GetWhereAsync(o => o.ID == orderId && !o.isDeleted, false,
                "Details.Product.Colors",
                "Details.Product.Sizes",
                "Details.Product.Images",
                "Details.SelectedColor",
                "Details.SelectedSize",
                "OrderPayment",
                "Shipping",
                "Customer.Addresses");
            if (order == null) throw new NotFoundException("sifariş");
            var details = order.Details;
            var products = order.Details.Select(d => d.Product);
            var colors = order.Details.Select(d => d.Product.Colors);
            var sizes = order.Details.Select(d => d.Product.Sizes);
            var images = order.Details.Select(d => d.Product.Images.FirstOrDefault(i => i.IsMain));
            var dto = new OrderGetSingleDto
            {
                Id = order.ID.ToString(),
                OrderTrackingNumber = order.OrderTrackingNumber,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                DiscountedPrice = order.DiscountedPrice,
                SavingAmount = order.SavingAmount,
                RequiredDate = order.RequiredDate,
                CustomerID = order.CustomerID,
                CustomerName = order.Customer.FullName,
                CustomerEmail = order.Customer.Email,
                CustomerPhone = order.Customer.PhoneNumber,
                OrderPaymentStatus = order.OrderPayment.PaymentStatus.ToString(),
                OrderPaymentDate = order.OrderPayment.PaymentDate != null ? order.OrderPayment.PaymentDate.ToString() : "Ödənilməyib",
                OrderStatus = order.OrderStatus.ToString(),
                OrderPaymentType = order.OrderPayment.PaymentMethod.ToString(),
                ShippingAddress = order.Customer.Addresses.FirstOrDefault(a => a.IsCurrentAddress && !a.isDeleted).FullAddress,
                ShippingStatus = order.Shipping.ShippingStatus.ToString(),
                ShippingType = order.Shipping.ShippingType.ToString(),
                Details = details.Select(detail => new OrderDetailGetSingleDto
                {
                    Id = detail.ID.ToString(),
                    Price = detail.Price,
                    Quantity = detail.Quantity,
                    ProductId = detail.ProductID.ToString(),
                    ProductName = detail.Product.Name,
                    ProductDescription = detail.Product.Description,
                    ProductImageName = detail.Product.Images.FirstOrDefault(i => i.IsMain).FileName,
                    ProductImageURl = detail.Product.Images.FirstOrDefault(i => i.IsMain).Path,
                    ProductColor = detail.SelectedColor.ColorName,
                    ProductSize = detail.SelectedSize.SizeName,
                }).ToList()
            };
            return dto;
        }
    }
}
