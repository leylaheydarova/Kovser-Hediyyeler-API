using AutoMapper;
using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class SocialMediaMapper:Profile
    {
        public SocialMediaMapper()
        {
            CreateMap<SocialMediaDto, SocialMedia>().ReverseMap();
        }
    }
}
