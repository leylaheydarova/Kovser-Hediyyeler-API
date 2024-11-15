namespace KovserHediyyeler.Application.DTOs.Employees
{
    public class EmployeeGetAllDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relationships
        public string PositionName { get; set; }

    }
}
