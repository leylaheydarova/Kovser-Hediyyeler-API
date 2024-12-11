using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
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
        readonly UserManager<WebUser> _userManager;

        public WishListService(IWishListReadRepository listReadRepository, IWishListWriteRepository listWriteRepository, IWishListItemReadRepository itemReadRepository, IWishListItemWriteRepository itemWriteRepository, UserManager<WebUser> userManager)
        {
            _listReadRepository = listReadRepository;
            _listWriteRepository = listWriteRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
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
            var list = await _listReadRepository.GetWhereAsync(l => l.CustomerID == webUser.Id && !l.isDeleted, true, "ListItems");
            if (list == null) throw new NotFoundException("sevimlilər siyahısı");
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

                var item = await _itemReadRepository.Table.Include(i => i.List).Include(i => i.Product).FirstOrDefaultAsync(i => i.WishListID == list.ID && !i.isDeleted);
                if (item == null)
                {
                    item = new WishListItem
                    {
                        ID = Guid.NewGuid(),
                        ProductID = productId,
                        WishListID = list.ID,
                    };
                    list.ListItems.Add(item);
                    await _itemWriteRepository.AddAsync(item);
                    await _listWriteRepository.AddAsync(list);
                    await _itemWriteRepository.SaveAsync();
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

        public async Task RemoveItemFromWishListAsync(string customerId, Guid productId)
        {
            using var transaction = await _listWriteRepository.BeginTransactionAsync();
            try
            {
                var list = await GetUserWishListASync(customerId);

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

