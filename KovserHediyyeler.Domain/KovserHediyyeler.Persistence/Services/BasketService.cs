using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
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
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly UserManager<WebUser> _userManager;


        public BasketService(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository itemReadRepository, IBasketItemWriteRepository itemWriteRepository, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, UserManager<WebUser> userManager)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _userManager = userManager;
        }

        async Task<WebUser> GetUserAsync(string userId)
        {
            var webUser = await _userManager.FindByIdAsync(userId);
            if (webUser == null) throw new UserNotFoundException();
            return webUser;
        }


        public async Task AddItemToBasketAsync(Guid productId, int count, string userId)
        {
            using var transaction = await _basketWriteRepository.BeginTransactionAsync();
            try
            {
                var webUser = await GetUserAsync(userId);
                var basket = await _basketReadRepository.GetWhereAsync(b => b.CustomerID == webUser.Id && !b.isDeleted, true);
                if (basket.BasketItems == null)
                {
                    basket.BasketItems = new List<BasketItem>();
                }
                var product = await _productReadRepository.GetWhereAsync(p => p.ID == productId && !p.isDeleted, true);
                if (product == null) throw new ProductNotFoundException();
                var item = await _itemReadRepository.Table.Include(i => i.Basket).Include(i => i.Product).FirstOrDefaultAsync(i => i.ProductID == product.ID && i.BasketID == basket.ID && !i.isDeleted);
                if (item == null)
                {
                    item = new BasketItem
                    {
                        ID = Guid.NewGuid(),
                        Basket = basket,
                        BasketID = basket.ID,
                        ProductID = product.ID,
                        Product = product,
                        ProductCount = count,

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

                basket.TotalPrice += basket.BasketItems.Sum(i => i.ProductCount * i.Product.DiscountedPrice); //frontda qiymet 0 olarsa, free yazilsin
                basket.Count += basket.BasketItems.Sum(i => i.ProductCount);

                _basketWriteRepository.Update(basket);

                await _basketWriteRepository.SaveAsync();
                await _productWriteRepository.SaveAsync();
                await _itemWriteRepository.SaveAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RemoveItemFromBasketAsync(Guid productId, string customerId)
        {
            using var transaction = await _basketWriteRepository.BeginTransactionAsync();
            try
            {
                var webUser = await GetUserAsync(customerId);
                var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == webUser.Id, true, "BasketItems.Product");
                var product = await _productReadRepository.GetWhereAsync(p => p.ID == productId && !p.isDeleted, false);
                if (product == null) throw new ProductNotFoundException();
                var item = basket.BasketItems.FirstOrDefault(i => i.ProductID == productId && !i.isDeleted);
                if (item == null || basket == null)
                {
                    throw new FailException();
                }

                basket.Count -= item.ProductCount;
                basket.TotalPrice -= (item.Product.DiscountedPrice * item.ProductCount);
                _itemWriteRepository.RemovePermanently(item);
                await _itemWriteRepository.SaveAsync();

                _basketWriteRepository.Update(basket);
                await _basketWriteRepository.SaveAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
