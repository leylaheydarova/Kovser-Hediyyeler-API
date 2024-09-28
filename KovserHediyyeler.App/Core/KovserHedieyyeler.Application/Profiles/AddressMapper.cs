using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class AddressMapper:Profile
    {
        public AddressMapper()
        {
            CreateMap<AddressCommandDto, Address>().ReverseMap();
            CreateMap<Address, AddressGetDto>().ReverseMap();
        }
    }
}
