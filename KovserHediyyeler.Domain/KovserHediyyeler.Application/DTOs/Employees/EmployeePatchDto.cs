
namespace KovserHedieyyeler.Application.DTOs.Employees
{
    public class EmployeePatchDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public bool? isRemote { get; set; }

        //Relationships
        public Guid? DepartmentID { get; set; }
        public Guid? PositionID { get; set; }
        public Guid? ShopID { get; set; }
    }
}
