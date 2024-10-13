using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Profiles
{
    public class PositionMapper:Profile
    {
        public PositionMapper()
        {
            CreateMap<PositionCommandDto, Position>().ReverseMap();
            CreateMap<Position, PositionGetDto>()
                .ForMember(dto => dto.Id, mod => mod.MapFrom(src => src.ID.ToString()))
                .ReverseMap();
        }
    }
}
