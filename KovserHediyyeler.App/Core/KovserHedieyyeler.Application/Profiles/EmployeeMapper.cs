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
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.FirstOrDefault(y => y.IsCurrentAddress)))
                .ReverseMap();
        }
    }
}
