using KovserHedieyyeler.Application.Const;
using KovserHedieyyeler.Application.CustomAttributes;
using KovserHedieyyeler.Application.Enums;
using KovserHedieyyeler.Application.Features.Commands.Role.CreateRole;
using KovserHedieyyeler.Application.Features.Commands.Role.DeleteRole;
using KovserHedieyyeler.Application.Features.Commands.Role.UpdateRole;
using KovserHedieyyeler.Application.Features.Queries.Role.GetRoleById;
using KovserHedieyyeler.Application.Features.Queries.Role.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Role By Id", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetRoles([FromRoute] GetRoleByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = AuthorizeDefinitionConstants.Roles)]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest request)
        {
            CreateRoleCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = AuthorizeDefinitionConstants.Roles)]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateRole([FromRoute] string id, string name)
        {
            var request = new UpdateRoleCommandRequest
            {
                Id = id,
                Name = name
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = AuthorizeDefinitionConstants.Roles)]
        [HttpDelete("RemoveRole")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var request = new DeleteRoleCommandRequest
            {
                Id = id
            };
            DeleteRoleCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
