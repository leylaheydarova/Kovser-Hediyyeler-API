using KovserHedieyyeler.Application.Repositories.Abstractions.Banks;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Banks
{
    public class CustomerBankCardReadRepository : ReadRepository<CustomerBankCard>, ICustomerBankCardReadRepository
    {
        public CustomerBankCardReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
