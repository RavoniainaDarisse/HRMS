using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Project
    {
        public int Id { get; set; }  
        public string? Name { get; set; } 
        public string? Code { get; set; } 
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }  
        public DateTime? EndDate { get; set; }  
        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; } 
        public string? Client { get; set; } 
        public ProjectStatus Status { get; set; } = ProjectStatus.InProgress;  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  
        public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }

    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Cancelled
    }
}
