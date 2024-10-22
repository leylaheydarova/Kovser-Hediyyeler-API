using KovserHedieyyeler.Application.DTOs.Colors;
using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isSingleColour { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DiscountPersentage DiscountPercentage { get; set; } //request int
        //Relationships
        public Guid DepartmentID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid? BrandID { get; set; }

        public ICollection<Guid> ShopIDs { get; set; }
        public ICollection<ProductPropertyPostDto> ProductProperties { get; set; } = new List<ProductPropertyPostDto>();
        public ICollection<ProductImagePostDto> ProductImages { get; set; } = new List<ProductImagePostDto>();
        public ICollection<ColorDto> Colors { get; set; } = new List<ColorDto>();
        //public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
