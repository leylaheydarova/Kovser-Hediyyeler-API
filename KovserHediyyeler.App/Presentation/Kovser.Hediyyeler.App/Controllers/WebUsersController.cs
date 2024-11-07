//using KovserHedieyyeler.Application.CustomAttributes;
//using KovserHedieyyeler.Application.Enums;
//using KovserHedieyyeler.Application.Features.Commands.WebUsers.AssignRoleToUser;
using KovserHedieyyeler.Application.Features.Commands.WebUsers.Register;
//using KovserHedieyyeler.Application.Features.Commands.WebUsers.UpdatePassword;
//using KovserHedieyyeler.Application.Features.Queries.WebUsers.GetAllUsers;
//using KovserHedieyyeler.Application.Features.Queries.WebUsers.GetRolesToUsers;
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

        //[HttpPost("Update-Password")]
        //public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        //{
        //    UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
        //    return Ok(response);
        //}

        //[HttpGet]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = "Users")]
        //public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
        //{
        //    GetAllUsersQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
        //    return Ok(response);
        //}

        //[HttpGet("get-roles-to-user/{UserId}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Users", Menu = "Users")]
        //public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQueryRequest getRolesToUserQueryRequest)
        //{
        //    GetRolesToUserQueryResponse response = await _mediator.Send(getRolesToUserQueryRequest);
        //    return Ok(response);
        //}

        //[HttpPost("assign-role-to-user")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Assign Role To User", Menu = "Users")]
        //public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
        //{
        //    AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
        //    return Ok(response);
        //}

    }
}
