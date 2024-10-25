using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Accounts;
using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
//using KovserHediyyeler.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class WebUserMapper:Profile
    {
        public WebUserMapper()
        {
            //CreateMap<WebUser, WebUserGetAllDto>().ReverseMap();
            //CreateMap<WebUser, WebUserGetSingleDto>().ReverseMap();
            //CreateMap<RegisterDto, WebUser>().ReverseMap();
        }
    }
}
