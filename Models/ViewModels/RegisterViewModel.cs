using HRMS.Models;
using System.ComponentModel.DataAnnotations;

namespace HRMS.ViewModels
{
    public class RegisterViewModel
    {
        [Required, StringLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }
    }
}
