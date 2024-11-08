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
        readonly IHttpContextAccessor _accessor;
        readonly UserManager<WebUser> _userManager;

        public BasketService(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository itemReadRepository, IBasketItemWriteRepository itemWriteRepository, IWishListItemWriteRepository wishListItemWriteRepository, UserManager<WebUser> userManager, IProductReadRepository productReadRepository, IHttpContextAccessor accessor)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _wishListItemWriteRepository = wishListItemWriteRepository;
            _userManager = userManager;
            _productReadRepository = productReadRepository;
            _accessor = accessor;
        }

        public async Task AddItemToBasketAsync(Guid productId, int count, string customerId)
        {
            var user = await _userManager.FindByIdAsync(customerId);
            if (user == null) throw new UserNotFoundException();
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true, "BasketItems");
            var product = await _productReadRepository.GetWhereAsync(p => p.ID == productId, false);
            if (product is null)
                throw new ProductNotFoundException();
            if (basket.BasketItems == null)
            {
                basket.BasketItems = new List<BasketItem>();
            }

            try
            {
                var item = await _itemReadRepository.GetWhereAsync(x => x.ProductID == product.ID && x.BasketID == basket.ID, true, "Product", "Basket");
                if (item == null)
                {
                    item = new BasketItem
                    {
                        ID = Guid.NewGuid(),
                        ProductCount = count,
                        ProductID = product.ID,
                        BasketID = basket.ID,

                    };
                    await _itemWriteRepository.AddAsync(item);
                    basket.BasketItems.Add(item);
                    product.BasketItems.Add(item);
                }
                else
                {
                    item.ProductCount += count;
                    _itemWriteRepository.Update(item);
                }

                await _itemWriteRepository.SaveAsync();

                try
                {
                    basket.TotalPrice = basket.BasketItems.Sum(i => i.Product.Price * i.ProductCount);
                    basket.Count = basket.BasketItems.Sum(i => i.ProductCount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                _basketWriteRepository.Update(basket);
                await _basketWriteRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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
