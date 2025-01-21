using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class LeaveRequest
    {

        public int Id { get; set; }  
        public int EmployeeId { get; set; } 
        public Employee? Employee { get; set; }  
        [Required]
        public DateTime StartDate { get; set; }  
        [Required]
        public DateTime EndDate { get; set; } 
        public required string Reason { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending; 
    }

    public enum LeaveStatus
    {
        Pending,
        Approved,
        Denied
    }
}
