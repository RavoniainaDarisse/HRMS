using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class Department
    {
        public int Id { get; set; }  

        [StringLength(100)]
        public required string Name { get; set; }  // Nom du département

        // [Required]
        // [StringLength(10)]
        public string? Code { get; set; }  // Code unique du département (ex: HR, IT, FIN)

        public string? Description { get; set; }  // Description du département
        
        [ForeignKey("Employee")]
        public int? ManagerId { get; set; }  // Clé étrangère vers un employé responsable
        public Employee? Manager { get; set; }  

        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }  // Budget annuel du département
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Date de création
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Dernière mise à jour

        public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
