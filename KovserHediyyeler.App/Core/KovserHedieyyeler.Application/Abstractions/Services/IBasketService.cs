using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task AddItemToBasketAsync(Guid productId, int count, string customerId);
        public Task RemoveItemFromBasketAsync(Guid productId, string customerId);
        public Task RemoveItemFromBasketAddWishListAsyn(Guid productId, string customerId);
        public Task UpdateItemCountAsync(Guid productId, int newCount, string customerId);
        public Task<Basket> GetBasketAsync(string customerId);
        public Task ClearBasketAsync(string customerId);
        public Task<double> GetTotalPriceAsync(string customerId);
        public Task<int> GetTotalItemCountAsync(string customerId);
    }
}
