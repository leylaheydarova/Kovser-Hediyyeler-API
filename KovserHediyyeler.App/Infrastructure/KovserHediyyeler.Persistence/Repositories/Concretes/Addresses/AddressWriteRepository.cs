using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Addresses
{
    public class AddressWriteRepository : WriteRepository<Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
