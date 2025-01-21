using System.ComponentModel.DataAnnotations;

namespace HRMS.Models.domaine
{
    public class DepartementAdd
    {
        public required string Name { get; set; }
        public string? Code { get; set; } 
        public string? Description { get; set; }
        public int? ManagerId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }

    }
}