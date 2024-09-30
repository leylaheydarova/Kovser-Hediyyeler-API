using KovserHedieyyeler.Application.DTOs.Products;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Products
{
    public class ProductImageWriteRepository : WriteRepository<ProductImage>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
