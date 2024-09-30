using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Colors;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class ColorMapper:Profile
    {
        public ColorMapper()
        {
            CreateMap<ColorDto, ColorCode>().ReverseMap();
        }
    }
}
