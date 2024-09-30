using KovserHedieyyeler.Application.Repositories.Abstractions.Orders;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Orders
{
    public class OrderDetailReadRepository : ReadRepository<OrderDetail>, IOrderDetailReadRepository
    {
        public OrderDetailReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
