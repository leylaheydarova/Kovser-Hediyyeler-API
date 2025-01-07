using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Baskets;
using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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
            if (webUser == null) throw new NotFoundException("istifadəçi");
            return webUser;
        }

        async Task<Product> GetProductAsync(Guid productId)
        {
            Product product = await _productReadRepository.GetWhereAsync(p => p.ID == productId && !p.isDeleted, false);
            if (product == null) throw new NotFoundException("məhsul");
            return product;
        }

        async Task<Basket> FindBasketAsync(string customerId, bool istracking)
        {
            var webuser = await GetUserAsync(customerId);
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == webuser.Id, istracking);
            return basket;
        }

        async Task<Basket> FindBasketWithIncludeAsync(string customerId, bool istracking, string includes)
        {
            var webuser = await GetUserAsync(customerId);
            var basket = await _basketReadRepository.GetWhereAsync(x => x.CustomerID == webuser.Id, istracking, includes);
            return basket;
        }
       
        public async Task AddItemToBasketAsync(Guid productId, int count, string userId, Guid colorId, Guid sizeId)
        {
            using var transaction = await _basketWriteRepository.BeginTransactionAsync();
            try
            {
                var basket = await FindBasketAsync(userId, true);
                if (basket.BasketItems == null)
                {
                    basket.BasketItems = new List<BasketItem>();
                }
                var product = await GetProductAsync(productId);

                var color = product.Colors.FirstOrDefault(c => c.ID == colorId && !c.isDeleted);
                if (color == null) throw new NotFoundException("bu rəng");
                if (color.ColorStock <= 0) throw new FailException("Bu rəngdə məhsul tükənib. Zəhmət olmasa mövcud digər rənglərdən seçin.");
                var size = product.Sizes.FirstOrDefault(s => s.ID == sizeId && !s.isDeleted);
                if (size == null) throw new NotFoundException("bu ölçü");
                if (size.SizeStock <= 0) throw new FailException("Bu ölçüdə məhsul tükənib. Zəhmət olmasa mövcud digər ölçülərdən seçin.");


                //if (product.Department.Name != "Kövsər Hədiyyələr") //cunki handmade mehsullari stock-u free-dir ve istenilen sayda secile biler
                //{
                if (product.Stock < count) throw new InvalidCountException(count); 
                //}
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
                        SelectedColor = color,
                        SelectedSize = size
                    };
                    if(item.SelectedSize.SizeStock >= item.SelectedColor.ColorStock)
                    {
                        if (count > item.SelectedColor.ColorStock) throw new InvalidCountException(item.SelectedColor.ColorStock);
                        else item.ProductCount = count;
                    }
                    else
                    {
                        if (count > item.SelectedSize.SizeStock) throw new InvalidCountException(item.SelectedSize.SizeStock);
                        else item.ProductCount = count;
                    }
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
                var basket = await FindBasketWithIncludeAsync(customerId, true, "BasketItems.Product");
                var product = await GetProductAsync(productId);
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

        public async Task UpdateItemCountAsync(Guid productId, int newCount, string customerId)
        {
            using var transaction = await _basketWriteRepository.BeginTransactionAsync();
            try
            {
                var product = await GetProductAsync(productId);
                
                //if (product.Department.Name != "Kövsər Hədiyyələr")
                //{
                //if (product.Stock < newCount) throw new InvalidCountException(newCount);
                //}
                var basket = await FindBasketWithIncludeAsync(customerId, true, "BasketItems");
                if (basket.BasketItems == null)
                {
                    basket.BasketItems = new List<BasketItem>();
                }

                var item = await _itemReadRepository.GetWhereAsync(x => x.ProductID == product.ID && !x.isDeleted, true, "Product");
                var previousCount = item.ProductCount; //əvvəlki say
                if (item.SelectedSize.SizeStock >= item.SelectedColor.ColorStock)
                {
                    if (newCount > item.SelectedColor.ColorStock) throw new InvalidCountException(item.SelectedColor.ColorStock);
                    else item.ProductCount = newCount;
                }
                else
                {
                    if (newCount > item.SelectedSize.SizeStock) throw new InvalidCountException(item.SelectedSize.SizeStock);
                    else item.ProductCount = newCount;
                }

                basket.Count = (basket.Count - previousCount) + item.ProductCount;
                basket.TotalPrice = (basket.TotalPrice - (previousCount * item.Product.DiscountedPrice)) + (item.ProductCount * item.Product.DiscountedPrice);
                basket = item.Basket;
                _itemWriteRepository.Update(item);
                _basketWriteRepository.Update(basket);
                await _basketWriteRepository.SaveAsync();
                await _itemWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> ClearBasketAsync(string customerId)
        {
            using var transaction = await _basketWriteRepository.BeginTransactionAsync();
            try
            {
                Basket basket = await FindBasketWithIncludeAsync(customerId, true, "BasketItems");
                if (basket.BasketItems.Count == 0) return false;
                foreach (var item in basket.BasketItems)
                {
                    _itemWriteRepository.RemovePermanently(item);
                }
                await _itemWriteRepository.SaveAsync();
                basket.TotalPrice = 0;
                basket.Count = 0;
                _basketWriteRepository.Update(basket);
                await _basketWriteRepository.SaveAsync();
                await transaction.CommitAsync();
                return true;

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<BasketGetDto> GetBasketAsync(string customerId)
        {
            var query = _itemReadRepository.GetAllWhere(x => !x.isDeleted && x.Basket.CustomerID == customerId, false, "Product.Colors", "Product.Sizes");
            List<BasketItemGetDto> items = await query.Select(x => new BasketItemGetDto()
            {
                Id = x.ID.ToString(),
                ProductName = x.Product.Name,
                ProductCount = x.ProductCount,
                BasketID = x.BasketID.ToString(),
                DiscountedPrice = x.Product.DiscountedPrice,
                ProductPrice = x.Product.Price,
                SelectedColor = x.SelectedColor.ColorName,
                SelectedSize = x.SelectedSize.SizeName
            }).ToListAsync();
            var basket = await FindBasketWithIncludeAsync(customerId, false, "Customer");
            var dto = new BasketGetDto
            {
                Id = basket.ID.ToString(),
                Count = items.Sum(i => i.ProductCount),
                CustomerName = basket.Customer.FullName,
                TotalPrice = basket.TotalPrice,
                Items = items
            };
            return dto;
        }

        public async Task<double> GetTotalPriceAsync(string customerId)
        {
            var basket = await FindBasketAsync(customerId, false);
            double TotalPrice = basket.TotalPrice;
            return TotalPrice;
        }

        public async Task<int> GetTotalItemCountAsync(string customerId)
        {
            var basket = await FindBasketAsync(customerId, false);
            int Count = basket.Count;
            return Count;
        }

        public async Task SetIsSelectedTrueAsunc(List<Guid> productIds, string customerId)
        {
            var basket = await FindBasketAsync(customerId, false);

            foreach (var productId in productIds)
            {
                var item = await _itemReadRepository.GetWhereAsync(i => i.ProductID == productId && i.BasketID == basket.ID && !i.isDeleted, true);
                if (item is null) throw new InvalidInputException("məhsul");
                item.isSelected = true;
                _itemWriteRepository.Update(item);
            }
            await _itemWriteRepository.SaveAsync();
        }
    }
}
