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
    public class CustomerBankCardWriteRepository : WriteRepository<CustomerBankCard>, ICustomerBankCardWriteRepository
    {
        public CustomerBankCardWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
