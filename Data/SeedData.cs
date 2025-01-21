using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using HRMS.Models;


namespace HRMS.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Créer les rôles si non existants
            string[] roleNames = { "Admin", "Manager", "Employee" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Créer un utilisateur Admin par défaut
            var adminUser = await userManager.FindByEmailAsync("admin@hrms.com");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin@hrms.com",
                    Email = "admin@hrms.com",
                    FullName = "Admin User",
                    Role = UserRole.Admin 
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    // Attribuer le rôle Admin à l'utilisateur
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}