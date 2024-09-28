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
            CreateMap<BrandCommandDto, Brand>().ReverseMap();
            CreateMap<Brand, BrandGetDto>().ReverseMap();
        }
    }
}
