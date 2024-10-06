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
            CreateMap<Promotion, PromotionGetDto>().ReverseMap();
        }
    }
}
