using Cocktaily.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cocktaily.Database;

public static class AppDbInitializer
{
    public static async Task SeedAsync(AppDbContext context, UserManager<AppUser> userManager)
    {
        // Ensure database is created and migrated
        await context.Database.MigrateAsync();

        // Check if the user exists
        if (await userManager.FindByNameAsync("admin") == null)
        {
            var user = new AppUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, "AdminPassword123!"); // Set a strong password
        }
    }
}