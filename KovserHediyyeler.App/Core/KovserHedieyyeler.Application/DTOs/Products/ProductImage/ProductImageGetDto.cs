using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products.ProductImage
{
    public class ProductImageGetDto
    {
        public string Id { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public bool isMain { get; set; }
    }
}
