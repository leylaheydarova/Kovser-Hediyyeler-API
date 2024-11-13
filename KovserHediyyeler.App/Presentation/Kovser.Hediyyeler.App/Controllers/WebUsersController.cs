using KovserHedieyyeler.Application.Const;
using KovserHedieyyeler.Application.CustomAttributes;
using KovserHedieyyeler.Application.Enums;
using KovserHedieyyeler.Application.Features.Commands.WebUsers.AssignRoleToUser;
using KovserHedieyyeler.Application.Features.Commands.WebUsers.Register;
using KovserHedieyyeler.Application.Features.Commands.WebUsers.UpdatePassword;
using KovserHedieyyeler.Application.Features.Queries.WebUsers.GetAllUsers;
using KovserHedieyyeler.Application.Features.Queries.WebUsers.GetRolesToUsers;
using KovserHedieyyeler.Application.Features.Queries.WebUsers.GetSingleUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class WebUsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public WebUsersController(IMediator mediator)
        {
            _mediator = mediator;
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


        [HttpPost("Update-Password")]
        public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = AuthorizeDefinitionConstants.WebUsers)]
        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] GetAllUsersQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }


        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Single Users", Menu = AuthorizeDefinitionConstants.WebUsers)]
        [HttpGet("get-single-user")]
        public async Task<IActionResult> GetUserAsync([FromQuery] GetSingleUserQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        // [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Users", Menu = AuthorizeDefinitionConstants.WebUsers)]
        [HttpGet("get-roles-to-user/{UserId}")]
        public async Task<IActionResult> GetRolesToUserAsync([FromRoute] GetRolesToUserQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.UserRoles);
        }

        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Assign Role To User", Menu = AuthorizeDefinitionConstants.WebUsers)]
        [HttpPost("assign-role-to-user")]
        public async Task<IActionResult> AssignRoleToUserAsync(AssignRoleToUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
