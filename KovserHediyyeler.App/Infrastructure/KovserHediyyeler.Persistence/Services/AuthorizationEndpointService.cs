//using KovserHedieyyeler.Application.Repositories.Interfaces.Endpoints;
//using KovserHedieyyeler.Application.Repositories.Interfaces.Menus;
//using KovserHedieyyeler.Application.Repositories.Interfaces;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using KovserHedieyyeler.Application.Abstractions.Services;
//using KovserHedieyyeler.Application.Abstractions.Services.Configurations;
//using KovserHediyyeler.Domain.Models.Identity;
//using Microsoft.EntityFrameworkCore;
//using KovserHediyyeler.Domain.Models;

//namespace KovserHediyyeler.Persistence.Services
//{
//    public class AuthorizationEndpointService : IAuthorizationEndpointService
//    {
//        readonly IApplicationService _applicationService;
//        readonly IEndpointReadRepository _endpointReadRepository;
//        readonly IEndpointWriteRepository _endpointWriteRepository;
//        readonly IMenuReadRepository _menuReadRepository;
//        readonly IMenuWriteRepository _menuWriteRepository;
//        readonly RoleManager<Role> _roleManager;

//        public AuthorizationEndpointService(IApplicationService applicationService, IEndpointReadRepository endpointReadRepository, IEndpointWriteRepository endpointWriteRepository, IMenuReadRepository menuReadRepository, IMenuWriteRepository menuWriteRepository, RoleManager<UserRole> roleManager)
//        {
//            _applicationService = applicationService;
//            _endpointReadRepository = endpointReadRepository;
//            _endpointWriteRepository = endpointWriteRepository;
//            _menuReadRepository = menuReadRepository;
//            _menuWriteRepository = menuWriteRepository;
//            _roleManager = roleManager;
//        }

//        public async Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
//        {
//            Menu _menu = await _menuReadRepository.GetWhereAsync(m => m.Name == menu, true);
//            if (_menu == null)
//            {
//                _menu = new()
//                {
//                    ID = Guid.NewGuid(),
//                    Name = menu
//                };
//                await _menuWriteRepository.AddAsync(_menu);

//                await _menuWriteRepository.SaveAsync();
//            }

//            Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.Menu).Include(e => e.Roles).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);

//            if (endpoint == null)
//            {
//                var action = _applicationService.GetAuthorizeDefinitionEndpoints(type)
//                        .FirstOrDefault(m => m.Name == menu)
//                        ?.Actions.FirstOrDefault(e => e.Code == code);

//                endpoint = new()
//                {
//                    Code = action.Code,
//                    ActionType = action.ActionType,
//                    HttpType = action.HttpType,
//                    Definition = action.Definition,
//                    ID = Guid.NewGuid(),
//                    Menu = _menu
//                };

//                await _endpointWriteRepository.AddAsync(endpoint);
//                await _endpointWriteRepository.SaveAsync();
//            }

//            foreach (var role in endpoint.Roles)
//                endpoint.Roles.Remove(role);

//            var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

//            foreach (var role in appRoles)
//                endpoint.Roles.Add(role);

//            await _endpointWriteRepository.SaveAsync();
//        }

//        public async Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
//        {
//            Endpoint? endpoint = await _endpointReadRepository.Table
//               .Include(e => e.Roles)
//               .Include(e => e.Menu)
//               .FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
//            if (endpoint != null)
//                return endpoint.Roles.Select(r => r.Name).ToList();
//            return null;
//        }
//    }
//}
