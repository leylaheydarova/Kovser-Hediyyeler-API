//using KovserHediyyeler.Application.Abstractions;
//using KovserHediyyeler.Application.DTOs.Orders;
//using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
//using KovserHediyyeler.Application.Repositories.Baskets;
//using KovserHediyyeler.Application.Repositories.Orders;
//using KovserHediyyeler.Domain.Enums;
//using KovserHediyyeler.Domain.Models;
//using Microsoft.AspNetCore.Identity;

//namespace KovserHediyyeler.Persistence.Services
//{
//    public class OrderService : IOrderService//png.form-post edir, shablon melumat uzerinde datalar elave olunur.
//    {
//        readonly IOrderReadRepository _orderReadRepository;
//        readonly IOrderWriteRepository _orderWriteRepository;
//        readonly IOrderDetailReadRepository _orderDetailReadRepository;
//        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;
//        readonly IOrderPaymentReadRepository _orderPaymentReadRepository;
//        readonly IOrderPaymentWriteRepository _orderPaymentWriteRepository;
//        readonly IShippingReadRepository _shippingReadRepository;
//        readonly IShippingWriteRepository _shippingWriteRepository;
//        readonly IBasketItemReadRepository _basketItemReadRepository;
//        readonly IBasketReadRepository _basketReadRepository;
//        readonly UserManager<WebUser> _userManager;
//        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IOrderDetailReadRepository orderDetailReadRepository, IOrderDetailWriteRepository orderDetailWriteRepository, IOrderPaymentReadRepository orderPaymentReadRepository, IOrderPaymentWriteRepository orderPaymentWriteRepository, IShippingReadRepository shippingReadRepository, IShippingWriteRepository shippingWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketReadRepository basketReadRepository, UserManager<WebUser> userManager)
//        {
//            _orderReadRepository = orderReadRepository;
//            _orderWriteRepository = orderWriteRepository;
//            _orderDetailReadRepository = orderDetailReadRepository;
//            _orderDetailWriteRepository = orderDetailWriteRepository;
//            _orderPaymentReadRepository = orderPaymentReadRepository;
//            _orderPaymentWriteRepository = orderPaymentWriteRepository;
//            _shippingReadRepository = shippingReadRepository;
//            _shippingWriteRepository = shippingWriteRepository;
//            _basketItemReadRepository = basketItemReadRepository;
//            _basketReadRepository = basketReadRepository;
//            _userManager = userManager;
//        }
//        async Task<WebUser> GetUserAsync(string userId)
//        {
//            var webUser = await _userManager.FindByIdAsync(userId);
//            if (webUser == null) throw new NotFoundException("istifadəçi");
//            return webUser;
//        }
//        string GenerateTrackingNumber(string prefix)
//        {
//            var date = DateTime.Now.AddHours(4);
//            var trackingString = $"{prefix}{date}";
//            return trackingString;
//        } //todo: datetime formati daha oxunaqlidir, onu sadece yanyana reqemler sekline cevir
//        public async Task<bool> CreateOrderAsync(string customerId, OrderDto orderDto)
//        {
//            using var transaction = await _orderWriteRepository.BeginTransactionAsync();
//            var result = false;
//            try
//            {
//                var webUser = await GetUserAsync(customerId);
//                var basket = await _basketReadRepository.GetWhereAsync(b => b.CustomerID == webUser.Id && !b.isDeleted, false, "BasketItems.Product", "Customer");
//                if (basket == null) throw new NotFoundException("səbət");
//                var items = basket.BasketItems.Where(i => i.isSelected);

//                List<OrderDetailCreateDto> detailDtos = new List<OrderDetailCreateDto>();
//                foreach (var item in items)
//                {
//                    var detailDto = new OrderDetailCreateDto
//                    {
//                        Quantity = item.ProductCount,
//                        DiscountedPrice = (item.Product.DiscountedPrice * item.ProductCount),
//                        Price = (item.Product.Price * item.ProductCount),
//                        ProductID = item.ProductID,
//                    };
//                    detailDtos.Add(detailDto);
//                }

//                var order = new Order
//                {
//                    ID = Guid.NewGuid(),
//                    OrderTrackingNumber = GenerateTrackingNumber("ORD"),
//                    CustomerID = webUser.Id,
//                    TotalPrice = detailDtos.Sum(d => d.Price),
//                    DiscountedPrice = detailDtos.Sum(d => d.DiscountedPrice),
//                    SavingAmount = (detailDtos.Sum(d => d.Price) - detailDtos.Sum(d => d.DiscountedPrice)),
//                    OrderDate = DateTime.Now.AddHours(4),
//                    RequiredDate = DateTime.Now.AddHours(4).AddDays(25),
//                    OrderStatus = OrderStatus.SifarişAlındı
//                };

//                foreach (var dto in detailDtos)
//                {
//                    var detail = new OrderDetail
//                    {
//                        ID = Guid.NewGuid(),
//                        OrderID = order.ID,
//                        Price = dto.DiscountedPrice,
//                        ProductID = dto.ProductID,
//                        Quantity = dto.Quantity,
//                    };
//                    order.Details.Add(detail);
//                    await _orderDetailWriteRepository.AddAsync(detail);
//                }

//                order.OrderPayment = new OrderPayment
//                {
//                    ID = Guid.NewGuid(),
//                    Currency = orderDto.Currency,
//                    PaymentMethod = orderDto.PaymentMethod,
//                    PaymentStatus = orderDto.PaymentStatus,
//                    PaymentDate = orderDto.PaymentStatus == PaymentStatus.Paid ? DateTime.Now.AddHours(4) : null,
//                    OrderID = order.ID
//                };
//                await _orderPaymentWriteRepository.AddAsync(order.OrderPayment);

//                if (order.OrderPayment.PaymentStatus == PaymentStatus.Paid)
//                {
//                    order.Shipping = new Shipping
//                    {
//                        ID = Guid.NewGuid(),
//                        OrderID = order.ID,
//                        ShippingStatus = ShippingStatus.Gözləmədə,
//                        ShippingType = orderDto.ShippingType,
//                    };
//                    await _shippingWriteRepository.AddAsync(order.Shipping);
//                }

//                await _orderDetailWriteRepository.SaveAsync();
//                await _shippingWriteRepository.SaveAsync();
//                await _orderPaymentWriteRepository.SaveAsync();
//                await _orderWriteRepository.SaveAsync();
//                await transaction.CommitAsync();
//                result = true;
//                return result;
//            }
//            catch (Exception)
//            {
//                await transaction.RollbackAsync();
//                result = false;
//                throw;

//            }

//        }
//    }
//}
