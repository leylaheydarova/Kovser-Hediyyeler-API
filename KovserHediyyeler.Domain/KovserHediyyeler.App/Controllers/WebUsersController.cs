using KovserHediyyeler.Application.Features.Commands.WebUsers.AddAddressToUser;
using KovserHediyyeler.Application.Features.Commands.WebUsers.AddOrUpdateRole;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Clients;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Moderators;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Remove.RemoveAccount;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Remove.RemoveAddress;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdatePassword;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUser;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUserAddress;
using KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUserAddresses;
using KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUserRoles;
using KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUsers;
using KovserHediyyeler.Application.Features.Queries.WebUsers.GetSingle;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllUsersQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("getAllUserAddresses")]
        public async Task<IActionResult> GetAllUserAddressesAsync([FromQuery] GetAllUserAddressesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("getAllUserRoles{userIdOrEmail}")]
        public async Task<IActionResult> GetAllUserRolesAsync([FromRoute] string userIdOrEmail)
        {
            var request = new GetAllUserRolesQueryRequest
            {
                UserIdOrEmail = userIdOrEmail
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Roles);
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

        [HttpPost("addOrUpdateRoleToUser")]
        public async Task<IActionResult> AddOrUpdateRoleToUserAsync(AddOrUpdateUserRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{userIdOrEmail}")]
        public async Task<IActionResult> GetSingleUserAsync([FromRoute] string userIdOrEmail)
        {
            var request = new GetSingleUserQueryRequest()
            {
                UserIdOrEmail = userIdOrEmail
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("removeUserAddress")]
        public async Task<IActionResult> RemoveUserAddressAsync(RemoveUserAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("removeAccount")]
        public async Task<IActionResult> RemoveAccountAsync(RemoveAccountCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch("updateUser")]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch("updateUserAddress")]
        public async Task<IActionResult> UpdateUserAddressAsync(UpdateUserAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("updatePassword")]
        public async Task<IActionResult> UpdatePasswordAsync(UpdatePasswordCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
