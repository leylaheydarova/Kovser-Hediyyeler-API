//using KovserHedieyyeler.Application.Abstractions.Services;
//using KovserHedieyyeler.Application.DTOs.Baskets;
//using KovserHedieyyeler.Application.Repositories.Abstractions.Baskets;
//using KovserHedieyyeler.Application.Repositories.Abstractions.Orders;
//using KovserHediyyeler.Domain.Models;
//using KovserHediyyeler.Domain.Models.Identity;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KovserHediyyeler.Persistence.Services
//{
//    public class BasketService : IBasketService
//    {
//        readonly IHttpContextAccessor _httpContextAccessor;
//        readonly UserManager<WebUser> _userManager;
//        readonly IOrderReadRepository _orderReadRepository;
//        readonly IBasketWriteRepository _basketWriteRepository;
//        readonly IBasketReadRepository _basketReadRepository;
//        readonly IBasketItemWriteRepository _basketItemWriteRepository;
//        readonly IBasketItemReadRepository _basketItemReadRepository;

//        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<WebUser> userManager, IOrderReadRepository orderReadRepository, IBasketWriteRepository basketWriteRepository, IBasketReadRepository basketReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketItemReadRepository basketItemReadRepository)
//        {
//            _httpContextAccessor = httpContextAccessor;
//            _userManager = userManager;
//            _orderReadRepository = orderReadRepository;
//            _basketWriteRepository = basketWriteRepository;
//            _basketReadRepository = basketReadRepository;
//            _basketItemWriteRepository = basketItemWriteRepository;
//            _basketItemReadRepository = basketItemReadRepository;
//        }

//        private async Task<Basket?> ContextUser()
//        {
//            throw new Exception();
//            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
//            if (!string.IsNullOrEmpty(username))
//            {
//                List<WebUser> users = await _userManager.Users
//                    .Include(u => u.Basket)
//                    .ToListAsync();
//                foreach (var user in users)
//                {
//                    var _basket = from user in users
//                                  join basket in _basketReadRepository.Table
//                                  on user.BasketID equals basket.ID
//                                  join order in _orderReadRepository.Table
//                                  on basket.ID equals order. into BasketOrders
//                                  from order in BasketOrders.DefaultIfEmpty()
//                                  select new
//                                  {
//                                      Basket = basket,
//                                      Order = order,
//                                      User = user
//                                  };

//                }
//            }
//        }

//        public Basket? GetUserActiveBasket => throw new NotImplementedException();

//        public Task AddItemToBasketAsync(BasketItemGetDto dto)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<BasketItem>> GetBasketItemsAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task RemoveBasketItemAsync(string basketItemId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdateQuantityAsync(BasketItemGetDto dto)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
