using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Accounts;
using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHedieyyeler.Application.Repositories.Abstractions.Baskets;
using KovserHedieyyeler.Application.Repositories.Abstractions.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.CreateAsync(request.Dto);
            
            return new RegisterUserCommandResponse()
            {
                userResponse = response
            };
        }
    }
}
