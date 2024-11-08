using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Baskets;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Baskets;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHedieyyeler.Application.Repositories.Abstractions.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KovserHediyyeler.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketItemReadRepository _itemReadRepository;
        readonly IBasketItemWriteRepository _itemWriteRepository;
        readonly IWishListItemWriteRepository _wishListItemWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IHttpContextAccessor _accessor;
        readonly UserManager<WebUser> _userManager;

        public BasketService(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository itemReadRepository, IBasketItemWriteRepository itemWriteRepository, IWishListItemWriteRepository wishListItemWriteRepository, UserManager<WebUser> userManager, IProductReadRepository productReadRepository, IHttpContextAccessor accessor, IProductWriteRepository productWriteRepository)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _wishListItemWriteRepository = wishListItemWriteRepository;
            _userManager = userManager;
            _productReadRepository = productReadRepository;
            _accessor = accessor;
            _productWriteRepository = productWriteRepository;
        }

        private string GetUserIdAsync()
        {
            var userId = _accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) throw new UserNotFoundException();
            return userId;
        }

        public async Task AddItemToBasketAsync(Guid productId, int count)
        {
            var userId = GetUserIdAsync();
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

        public async Task ClearBasketAsync(string customerId)
        {
            Basket basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true);
            foreach (var item in basket.BasketItems)
            {
                _itemWriteRepository.RemovePermanently(item);
                await _itemWriteRepository.SaveAsync();
            }
            _basketWriteRepository.Update(basket);
            await _basketWriteRepository.SaveAsync();
        }

        public async Task<BasketGetDto> GetBasketAsync(string customerId)
        {
            var query = _itemReadRepository.GetAllWhere(x => !x.isDeleted && x.Basket.CustomerID == customerId, false, "Product");
            List<BasketItemGetDto> items = await query.Select(x => new BasketItemGetDto()
            {
                Id = x.ID.ToString(),
                ProductName = x.Product.Name,
                ProductCount = x.ProductCount,
                BasketID = x.BasketID.ToString(),
                DiscountedPrice = x.Product.DiscountedPrice,
                ProductPrice = x.Product.Price
            }).ToListAsync();
            var basket = await _basketReadRepository.GetWhereAsync(x => !x.isDeleted && x.CustomerID == customerId, false, "Customer");
            var dto = new BasketGetDto
            {
                Id = basket.ID.ToString(),
                Count = query.Count(),
                CustomerName = basket.Customer.FullName,
                TotalPrice = basket.TotalPrice,
                Items = items
            };
            return dto;
        }

        public async Task<int> GetTotalItemCountAsync(string customerId)
        {
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, false);
            int Count = basket.Count;
            return Count;
        }

        public async Task<double> GetTotalPriceAsync(string customerId)
        {
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, false);
            double TotalPrice = basket.TotalPrice;
            return TotalPrice;
        }

        public async Task RemoveItemFromBasketAddWishListAsync(Guid productId, string customerId)
        {
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true);
            var item = basket.BasketItems.FirstOrDefault(x => x.ProductID == productId);
            if (item == null || basket == null)
            {
                return;
            }

            var listItem = new WishListItem
            {
                ID = Guid.NewGuid(),
                ProductID = item.ProductID,
                WishListID = basket.Customer.WishList.ID
            };

            await _wishListItemWriteRepository.AddAsync(listItem);
            await _wishListItemWriteRepository.SaveAsync();

            _itemWriteRepository.RemovePermanently(item);
            await _itemWriteRepository.SaveAsync();

            _basketWriteRepository.Update(basket);
            await _basketWriteRepository.SaveAsync();
        }

        public async Task RemoveItemFromBasketAsync(Guid productId, string customerId)
        {
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true);
            var item = basket.BasketItems.FirstOrDefault(x => x.ProductID == productId);
            if (item == null || basket == null)
            {
                return;
            }

            _itemWriteRepository.RemovePermanently(item);
            await _itemWriteRepository.SaveAsync();

            _basketWriteRepository.Update(basket);
            await _basketWriteRepository.SaveAsync();
        }

        public async Task UpdateItemCountAsync(Guid productId, int newCount, string customerId)
        {
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true, "BasketItems");
            if (basket.BasketItems == null)
            {
                basket.BasketItems = new List<BasketItem>();
            }

            var item = await _itemReadRepository.GetWhereAsync(x => x.ProductID == productId && !x.isDeleted, true, "Product");
            basket.Count = (basket.Count - item.ProductCount) + newCount;
            basket.TotalPrice = (basket.TotalPrice - (item.ProductCount * item.Product.Price)) + (newCount * item.Product.Price);
            item.ProductCount = newCount;
            basket = item.Basket;
            _itemWriteRepository.Update(item);
            _basketWriteRepository.Update(basket);
            await _basketWriteRepository.SaveAsync();
            await _itemWriteRepository.SaveAsync();
        }
    }
}
