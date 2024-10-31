using KovserHedieyyeler.Application.DTOs.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.Update
{
    public class UpdateBrandCommandRequest:UpdateCommandRequest<BrandUpdateDto>, IRequest<UpdateBrandCommandResponse>
    {
    }
}
