//using KovserHedieyyeler.Application.Abstractions.Services;
//using MediatR;

//namespace KovserHedieyyeler.Application.Features.Commands.AssignRoleEndpoint
//{
//    public class AssignRoleEndpointCommandHandler:IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
//    {
//        readonly IAuthorizationEndpointService _authorizationEndpointService;

//        public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
//        {
//            await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
//            return new()
//            {

//            };
//        }
//    }
//}
