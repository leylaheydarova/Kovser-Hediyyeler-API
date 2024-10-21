using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class PromotionMapper:Profile
    {
        public PromotionMapper()
        {
            CreateMap<PromotionCommandDto, Promotion>().ReverseMap();
            CreateMap<Promotion, PromotionGetSingleDto>()
                .ForMember(dto => dto.DiscountPersentage, mod => mod.MapFrom(src => src.DiscountPersentage.ToString()))
                .ForMember(dto => dto.Products, mod => mod.MapFrom(src => src.Products))
                //.ForMember(dto => dto.DepartmentNames, mod => mod.MapFrom(src => src.Departments))
                //.ForMember(dto => dto.CategoryNames, mod => mod.MapFrom(src => src.Categories))
                .ForMember(dto => dto.Id, mod => mod.MapFrom(src => src.ID.ToString()))
                .ReverseMap();
            CreateMap<Promotion, PromotionGetAllDto>()
                .ForMember(dto => dto.DiscountPersentage, mod => mod.MapFrom(src => src.DiscountPersentage.ToString()))
                .ReverseMap();
        }
    }
}
