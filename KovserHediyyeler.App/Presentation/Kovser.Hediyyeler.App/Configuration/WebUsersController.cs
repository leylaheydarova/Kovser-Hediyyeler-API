using KovserHedieyyeler.Application.Features.Commands.WebUsers.Register;
using KovserHediyyeler.Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Configuration
{
    [Route("api/[controller]/")]
    [ApiController]
    public class WebUsersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly RoleManager<Role> _roleManager;

        public WebUsersController(IMediator mediator, RoleManager<Role> roleManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.userResponse.isSucceeded == false)
            {
                return BadRequest();
            }
            return StatusCode(200, response);
        }

        [HttpPost(nameof(CreateRole))]
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin"
            });

            await _roleManager.CreateAsync(new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Moderator"
            });

            await _roleManager.CreateAsync(new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Client"
            });
            return Ok();
        }


    }
}
