using KovserHedieyyeler.Application.DTOs.Configuration;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Abstractions.Services.Configurations
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
