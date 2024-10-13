using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class EmployeeMapper:Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeCommandDto, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeGetDto>()
                .ForMember(dto => dto.Address, mod => mod.MapFrom(src => src.Address.FirstOrDefault(y => y.IsCurrentAddress)))
                .ForMember(dto => dto.ShopName, mod => mod.MapFrom(src => src.Shop.Name))
                .ForMember(dto => dto.PositionName, mod => mod.MapFrom(src => src.Position.Status))
                .ReverseMap();
        }
    }
}
