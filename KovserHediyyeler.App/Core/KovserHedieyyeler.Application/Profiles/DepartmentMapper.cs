using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Department;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class DepartmentMapper:Profile
    {
        public DepartmentMapper()
        {
            CreateMap<DepartmentCommandDto, Department>()
                .ForMember(dto => dto.LogoImage, mod => mod.MapFrom(src => src.file.Name))
                .ReverseMap();
            CreateMap<Department, DepartmentGetAllDto>().ReverseMap();
            CreateMap<Department, DepartmentGetSingleDto>()
                .ForMember(mod => mod.Id, dto => dto.MapFrom(src => src.ID.ToString()))
                .ReverseMap();
        }
    }
}
