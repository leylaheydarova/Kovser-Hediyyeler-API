using AutoMapper;
using KovserHediyyeler.Core.Entities;
using KovserHediyyeler.Service.Dtos.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Profiles
{
   public class DepartmentMap:Profile
    {
        public DepartmentMap()
        {
            CreateMap<DepartmentPostDto, Department>().ReverseMap();
            CreateMap<DepartmentPutDto, Department>().ReverseMap();
            CreateMap<Department, DepartmentGetDto>().ReverseMap();
        }
    }
}
