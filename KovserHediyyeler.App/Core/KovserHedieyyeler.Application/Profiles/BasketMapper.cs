using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Baskets;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class BasketMapper:Profile
    {
        public BasketMapper()
        {
            CreateMap<BasketItem, BasketItemGetDto>().ReverseMap();
        }
    }
}
