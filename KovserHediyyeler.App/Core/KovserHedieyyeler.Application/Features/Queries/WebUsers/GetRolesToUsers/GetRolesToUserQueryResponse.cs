namespace KovserHedieyyeler.Application.Features.Queries.WebUsers.GetRolesToUsers
{
    public class GetRolesToUserQueryResponse
    {
        public int StatusCode { get; set; } = 200;
        public string[] UserRoles { get; set; }
    }
}
