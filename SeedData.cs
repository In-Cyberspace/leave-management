using leave_management.Data;
using Microsoft.AspNetCore.Identity;

namespace leave_management
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                // Create "admin" user if it does not exist.
                Employee user = new Employee
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",
                    FirstName = "Admin",
                    LastName = "User"
                };

                // Assign the "Administrator" role to the newly created "admin" user.
                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Administrator"
                };

                roleManager.CreateAsync(role).Wait();
                // IdentityResult result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Employee"
                };

                roleManager.CreateAsync(role).Wait();
                // IdentityResult result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
