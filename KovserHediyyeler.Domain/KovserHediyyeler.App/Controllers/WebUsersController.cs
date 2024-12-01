using KovserHediyyeler.Application.Features.Commands.WebUsers.AddAddressToUser;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Clients;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Moderators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KovserHediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebUsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public WebUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("createModerator")]
        public async Task<IActionResult> RegisterModeratorAsync(RegisterModeratorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("addAddressToUser")]
        public async Task<IActionResult> AddAddressToUserAsync(AddAddressToUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
