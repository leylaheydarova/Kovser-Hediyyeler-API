using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class BrandMapper:Profile
    {
        public BrandMapper()
        {
            CreateMap<BrandCommandDto, Brand>()
                .ForMember(dto => dto.Image, mod => mod.MapFrom(src => src.file.FileName))
                .ReverseMap();
            CreateMap<Brand, BrandGetDto>()
                .ForMember(dto => dto.Id, mod => mod.MapFrom(src => src.ID.ToString()))
                .ReverseMap();
        }
    }
}
