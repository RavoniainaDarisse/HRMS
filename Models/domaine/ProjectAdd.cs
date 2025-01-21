using System.ComponentModel.DataAnnotations;

namespace HRMS.Models.domaine
{
    public class ProjectAdd
    {
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }
        public string? Client { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.InProgress;  
    }

      public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Cancelled
    }
}