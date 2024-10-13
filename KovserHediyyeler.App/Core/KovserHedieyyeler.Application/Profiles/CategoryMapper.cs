using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryCommandDto, Category>().ReverseMap();
            CreateMap<Category, CategoryGetDto>()
                .ForMember(x=>x.ParentCategoryName, y=>y.MapFrom(src=>src.ParentCategory.Name))
                .ForMember(dto => dto.Id, mod => mod.MapFrom(src => src.ID.ToString()))
                .ReverseMap();
        }
    }
}
