namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUserRoles
{
    public class GetAllUserRolesQueryResponse
    {
        public int StatusCode { get; set; } = 200;
        public string[] Roles { get; set; }
    }
}
