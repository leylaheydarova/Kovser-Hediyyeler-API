using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace KovserHediyyeler.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IHttpContextAccessor _accessor;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketItemReadRepository _itemReadRepository;
        readonly IBasketItemWriteRepository _itemWriteRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly UserManager<WebUser> _userManager;

        public BasketService(IHttpContextAccessor accessor, IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository itemReadRepository, IBasketItemWriteRepository itemWriteRepository, IProductWriteRepository productWriteRepository, UserManager<WebUser> userManager)
        {
            _accessor = accessor;
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _productWriteRepository = productWriteRepository;
            _userManager = userManager;
        }

        private async Task<string> GetUserIdAsync()
        {
            var userEmail = _accessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var webUser = await _userManager.FindByEmailAsync(userEmail);
            if (webUser == null) throw new UserNotFoundException();
            return webUser.Id;
        }
        public async Task AddItemToBasketAsync(Guid productId, int count)
        {
            var userId = await GetUserIdAsync();
            var basket = await _basketReadRepository.GetWhereAsync(b => b.CustomerID == userId && !b.isDeleted, true);
            if (basket.BasketItems == null)
            {
                basket.BasketItems = new List<BasketItem>();
            }

            var item = await _itemReadRepository.GetWhereAsync(i => i.ProductID == productId && i.BasketID == basket.ID && !i.isDeleted, true, "Product");
            if (item == null)
            {
                item = new BasketItem
                {
                    ID = Guid.NewGuid(),
                    BasketID = basket.ID,
                    ProductID = productId,
                    ProductCount = count
                };
                basket.BasketItems.Add(item);
                await _itemWriteRepository.AddAsync(item);
            }

            else
            {
                item.ProductCount += count;
                _itemWriteRepository.Update(item);
            }
            _productWriteRepository.Update(item.Product);

            basket.TotalPrice += basket.BasketItems.Sum(i => i.ProductCount * i.Product.DiscountedPrice);
            basket.Count += basket.BasketItems.Sum(i => i.ProductCount);

            _basketWriteRepository.Update(basket);

            await _basketWriteRepository.SaveAsync();
            await _productWriteRepository.SaveAsync();
            await _itemWriteRepository.SaveAsync();
        }
    }
}
