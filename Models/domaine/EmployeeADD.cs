namespace HRMS.Models.domaine
{
    public class EmployeeADD
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateHired { get; set; }
        public int? DepartmentId { get; set; }
        public int? ProjectId { get; set; }
    }
}