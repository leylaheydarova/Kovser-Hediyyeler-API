using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Orders;
using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Application.Repositories.Orders;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace KovserHediyyeler.Persistence.Services
{
    public class OrderService : IOrderService//png.form-post edir, shablon melumat uzerinde datalar elave olunur.
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

        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IOrderDetailReadRepository orderDetailReadRepository, IOrderDetailWriteRepository orderDetailWriteRepository, IOrderPaymentReadRepository orderPaymentReadRepository, IOrderPaymentWriteRepository orderPaymentWriteRepository, IShippingReadRepository shippingReadRepository, IShippingWriteRepository shippingWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketReadRepository basketReadRepository, UserManager<WebUser> userManager, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IBasketWriteRepository basketWriteRepository, IBasketItemWriteRepository basketItemWriteRepository)
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
            _basketReadRepository = basketReadRepository;
            _userManager = userManager;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _basketWriteRepository = basketWriteRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
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
            bool result;
            try
            {
                var webUser = await GetUserAsync(customerId);
                var basket = await _basketReadRepository.GetWhereAsync(b => b.CustomerID == webUser.Id && !b.isDeleted, false, "BasketItems", "Customer");
                if (basket == null) throw new NotFoundException("səbət");
                var items = _basketItemReadRepository.GetAllWhere(i => i.BasketID == basket.ID && i.isSelected && !i.isDeleted, true, "Product");
                if (items == null) result = false;
                List<OrderDetailCreateDto> detailDtos = new List<OrderDetailCreateDto>();
                foreach (var item in items)
                {
                    var detailDto = new OrderDetailCreateDto
                    {
                        Quantity = item.ProductCount,
                        DiscountedPrice = (item.Product.DiscountedPrice * item.ProductCount),
                        Price = (item.Product.Price * item.ProductCount),
                        ProductID = item.ProductID,
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
                        ProductID = dto.ProductID
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
                await _basketWriteRepository.SaveAsync();
                await _basketItemWriteRepository.SaveAsync();

                result = true;
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
    }
}
