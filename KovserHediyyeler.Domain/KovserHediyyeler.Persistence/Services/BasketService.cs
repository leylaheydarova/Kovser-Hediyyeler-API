using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
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

        public BasketService(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository itemReadRepository, IBasketItemWriteRepository itemWriteRepository, IProductWriteRepository productWriteRepository, UserManager<WebUser> userManager, IProductReadRepository productReadRepository)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _productWriteRepository = productWriteRepository;
            _userManager = userManager;
            _productReadRepository = productReadRepository;
        }


        public async Task AddItemToBasketAsync(Guid productId, int count, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new UserNotFoundException();
            var basket = await _basketReadRepository.GetWhereAsync(b => b.CustomerID == user.Id && !b.isDeleted, true);
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

            await _basketWriteRepository.SaveAsync(); //transaction arasdir tetbiq et
            await _productWriteRepository.SaveAsync();
            await _itemWriteRepository.SaveAsync();
        }
    }
}
