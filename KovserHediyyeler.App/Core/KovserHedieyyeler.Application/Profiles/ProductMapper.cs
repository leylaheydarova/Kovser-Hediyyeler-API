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
            CreateMap<Product, ProductGetAllDto>()
                .ForMember(dto => dto.Image, mod => mod.MapFrom(src => src.Images.FirstOrDefault(i => i.IsMain)))
                .ForMember(dto => dto.DepartmentName, mod => mod.MapFrom(src => src.Department.Name))
                .ReverseMap();
            CreateMap<Product, ProductGetSingleDto>()
                .ForMember(dto => dto.DepartmentName, mod => mod.MapFrom(src => src.Department.Name))
                .ForMember(dto => dto.CategoryName, mod => mod.MapFrom(src => src.Category.Name))
                .ForMember(dto => dto.BrandName, mod => mod.MapFrom(src => src.Brand.Name))
                .ForMember(dto => dto.ShopNames, mod => mod.MapFrom(src => src.Shops))
                .ForMember(dto => dto.Images, mod => mod.MapFrom(src => src.Images))
                .ForMember(dto => dto.Properties, mod => mod.MapFrom(src => src.Properties))
                .ForMember(dto => dto.Id, mod => mod.MapFrom(src => src.ID.ToString()))
                .ReverseMap();
            CreateMap<ProductImageDto, ProductImageFile>().ReverseMap();
            CreateMap<ProductPropertyDto, ProductProperty>().ReverseMap();  
        }
    }
}
