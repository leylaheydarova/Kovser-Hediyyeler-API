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
    public class OrderDetailWriteRepository : WriteRepository<OrderDetail>, IOrderDetailWriteRepository
    {
        public OrderDetailWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
