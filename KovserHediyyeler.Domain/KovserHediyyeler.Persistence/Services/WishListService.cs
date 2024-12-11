using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.WishLists;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Application.Repositories.WishLists;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class WishListService : IWishListService
    {
        readonly IWishListReadRepository _listReadRepository;
        readonly IWishListWriteRepository _listWriteRepository;
        readonly IWishListItemReadRepository _itemReadRepository;
        readonly IWishListItemWriteRepository _itemWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly UserManager<WebUser> _userManager;

        public WishListService(IWishListReadRepository listReadRepository, IWishListWriteRepository listWriteRepository, IWishListItemReadRepository itemReadRepository, IWishListItemWriteRepository itemWriteRepository, IProductReadRepository productReadRepository, UserManager<WebUser> userManager)
        {
            _listReadRepository = listReadRepository;
            _listWriteRepository = listWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _productReadRepository = productReadRepository;
            _userManager = userManager;
        }

        async Task<WebUser> GetUserAsync(string userId)
        {
            var webUser = await _userManager.FindByIdAsync(userId);
            if (webUser == null) throw new NotFoundException("istifadəçi");
            return webUser;
        }

        async Task<WishList> GetUserWishListASync(string customerId)
        {
            var webUser = await GetUserAsync(customerId);
            var list = await _listReadRepository.GetWhereAsync(l => l.CustomerID == webUser.Id && !l.isDeleted, true, "ListItems", "Customer");
            if (list == null)
            {
                list = new WishList
                {
                    ID = Guid.NewGuid(),
                    CustomerID = webUser.Id,
                    ListItems = new List<WishListItem>()
                };
                await _listWriteRepository.AddAsync(list);
                await _listWriteRepository.SaveAsync();
            }
            return list;
        }

        public async Task<bool> AddItemToWishListAsync(string customerId, Guid productId)
        {
            using var transaction = await _listWriteRepository.BeginTransactionAsync();
            try
            {
                bool isAdded = false;
                var list = await GetUserWishListASync(customerId);
                if (list.ListItems == null)
                {
                    list.ListItems = new List<WishListItem>();
                }

                var item = await _itemReadRepository.Table.Include(i => i.List).Include(i => i.Product).FirstOrDefaultAsync(i => i.WishListID == list.ID && i.ProductID == productId && !i.isDeleted);
                if (item == null)
                {
                    item = new WishListItem
                    {
                        ID = Guid.NewGuid(),
                        ProductID = productId,
                        WishListID = list.ID
                    };
                    list.ListItems.Add(item);
                    await _itemWriteRepository.AddAsync(item);
                    await _itemWriteRepository.SaveAsync();
                    _listWriteRepository.Update(list);
                    await _listWriteRepository.SaveAsync();
                    isAdded = true;
                }
                await transaction.CommitAsync();
                return isAdded;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> RemoveItemFromWishListAsync(string customerId, Guid productId)
        {
            using var transaction = await _listWriteRepository.BeginTransactionAsync();
            try
            {
                var list = await GetUserWishListASync(customerId);
                var product = await _productReadRepository.GetWhereAsync(p => p.ID == productId && !p.isDeleted, false);
                if (product == null) throw new NotFoundException("məhsul");
                var item = list.ListItems.FirstOrDefault(i => i.ProductID == product.ID && !i.isDeleted);
                if (item == null) return false;
                else
                {
                    _itemWriteRepository.RemovePermanently(item);
                }
                _listWriteRepository.Update(list);
                await _itemWriteRepository.SaveAsync();
                await _listWriteRepository.SaveAsync();
                await transaction.CommitAsync();
                return true;

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<WishListGetDto> GetWishListAsync(string customerId)
        {
            var list = await GetUserWishListASync(customerId);
            var dto = new WishListGetDto()
            {
                Id = list.ID.ToString(),
                CustomerName = list.Customer.FullName,
                ListItems = []
            };
            if (list.ListItems.Count > 0)
            {
                var query = _itemReadRepository.GetAllWhere(i => i.WishListID == list.ID && !i.isDeleted, false, "List", "Product.Images");
                List<WishListItemGetDto> items = await query.Select(e => new WishListItemGetDto
                {
                    Id = e.ID.ToString(),
                    ProductName = e.Product.Name,
                    ProductPrice = e.Product.Price,
                    DiscountedPrice = e.Product.DiscountedPrice,
                    ImageName = e.Product.Images.FirstOrDefault(i => i.IsMain).FileName,
                    ImageURL = e.Product.Images.FirstOrDefault(i => i.IsMain).Path
                }).ToListAsync();
                dto.ListItems = items;
            }
            return dto;
        }
    }
}

