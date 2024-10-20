using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class ShopMapper:Profile
    {
        public ShopMapper()
        {
            CreateMap<ShopCommandDto, Shop>().ReverseMap();
            CreateMap<Shop, ShopGetAllDto>().ReverseMap();
            CreateMap<Shop, ShopGetSingleDto>()
                .ForMember(dto => dto.Id, mod => mod.MapFrom(src => src.ID.ToString()))
                .ForMember(dto => dto.Address, mod => mod.MapFrom(src => src.Addresses.FirstOrDefault(ad => ad.IsCurrentAddress).FullAddress))
                .ReverseMap();
        }
    }
}
