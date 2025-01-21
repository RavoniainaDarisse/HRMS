using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HRMS.Models
{
    public class User : IdentityUser
    {
        [Required, StringLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public override string Email { get; set; } = string.Empty; 

        [Required]
        public UserRole Role { get; set; } = UserRole.Employee; // Rôle par défaut
        public string RoleAsString => Role.ToString(); 
    }

    public enum UserRole
    {
        Admin,
        Manager,
        Employee
    }
}
