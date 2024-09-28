using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Products;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductCommandDto, Product>().ReverseMap();
            CreateMap<Product, ProductGetAllDto>().ReverseMap();
            CreateMap<Product, ProductGetSingleDto>().ReverseMap();
            CreateMap<ProductImageDto, ProductImage>().ReverseMap();
            CreateMap<ProductPropertyDto, ProductProperty>().ReverseMap();  
        }
    }
}
