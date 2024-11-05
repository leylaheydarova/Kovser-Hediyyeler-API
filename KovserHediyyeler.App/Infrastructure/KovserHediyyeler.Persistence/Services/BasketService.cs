using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Repositories.Abstractions.Baskets;
using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketItemReadRepository _itemReadRepository;
        readonly IBasketItemWriteRepository _itemWriteRepository;

        public BasketService(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository itemReadRepository, IBasketItemWriteRepository itemWriteRepository)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
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

        public Task ClearBasketAsync(string customerId)
        {
            throw new NotImplementedException();
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

        public Task RemoveItemFromBasketAddWishListAsyn(Guid productId, string customerId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFromBasketAsync(Guid productId, string customerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemCountAsync(Guid productId, int newCount, string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
