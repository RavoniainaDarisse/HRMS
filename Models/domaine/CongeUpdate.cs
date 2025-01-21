namespace HRMS.Models.domaine
{
    public class CongeUpdate
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string Reason { get; set; }
        public LeaveStatus Status { get; set; }

        public enum LeaveStatus
        {
            Pending,
            Approved,
            Denied
        }
    }
}