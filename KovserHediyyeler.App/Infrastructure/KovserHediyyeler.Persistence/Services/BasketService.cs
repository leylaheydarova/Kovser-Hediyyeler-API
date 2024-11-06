using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Repositories.Abstractions.Baskets;
using KovserHedieyyeler.Application.Repositories.Abstractions.WishLists;
using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketItemReadRepository _itemReadRepository;
        readonly IBasketItemWriteRepository _itemWriteRepository;
        readonly IWishListWriteRepository _wishListWriteRepository;

        public BasketService(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository itemReadRepository, IBasketItemWriteRepository itemWriteRepository, IWishListWriteRepository wishListWriteRepository)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _wishListWriteRepository = wishListWriteRepository;
        }

        public async Task AddItemToBasketAsync(Guid productId, int count, string customerId)
        {
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true);
            if(basket.BasketItems == null)
            {
                basket.BasketItems = new List<BasketItem>();
            }

            try
            {
                var item = await _itemReadRepository.GetWhereAsync(x => x.ProductID == productId && x.BasketID == basket.ID, true);
                if (item == null)
                {
                    item = new BasketItem
                    {
                        ID = Guid.NewGuid(),
                        BasketID = basket.ID,
                        ProductID = productId,
                        ProductCount = count
                    };
                    await _itemWriteRepository.AddAsync(item);
                }
                else
                {
                    item.ProductCount += count;
                    _itemWriteRepository.Update(item);
                }
                await _itemWriteRepository.SaveAsync();

                basket.TotalPrice = basket.BasketItems.Sum(i => i.Product.Price * i.ProductCount);
                basket.Count = basket.BasketItems.Sum(i => i.ProductCount);
                _basketWriteRepository.Update(basket);
                await _basketWriteRepository.SaveAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ClearBasketAsync(string customerId)
        {
            Basket basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true);
            foreach(var item in basket.BasketItems)
            {
                _itemWriteRepository.RemovePermanently(item);
                await _itemWriteRepository.SaveAsync();
            }
            _basketWriteRepository.Update(basket);
            await _basketWriteRepository.SaveAsync();
        }

        public Task<Basket> GetBasketAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalItemCountAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetTotalPriceAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveItemFromBasketAddWishListAsync(Guid productId, string customerId)
        {
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == customerId, true);
            var item = basket.BasketItems.FirstOrDefault(x => x.ProductID == productId);
            if (item == null || basket == null)
            {
                return;
            }

            _itemWriteRepository.RemovePermanently(item);
            await _itemWriteRepository.SaveAsync();
            var wisList = new WishList
            {
                ID = Guid.NewGuid(),
                CustomerID = customerId,
                ListItems = new List<WishListItem>()
            };
            _wishListWriteRepository.AddAsync(wisList);
            _wishListWriteRepository.SaveAsync();

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

        public Task UpdateItemCountAsync(Guid productId, int newCount, string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
