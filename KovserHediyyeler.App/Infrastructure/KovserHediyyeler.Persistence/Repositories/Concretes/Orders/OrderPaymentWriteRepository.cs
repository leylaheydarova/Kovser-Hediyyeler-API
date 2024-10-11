using KovserHedieyyeler.Application.Repositories.Interfaces.Orders;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Orders
{
    public class OrderPaymentWriteRepository : WriteRepository<OrderPayment>, IOrderPaymentWriteRepository
    {
        public OrderPaymentWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
