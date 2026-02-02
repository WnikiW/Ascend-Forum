using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public static class ApplicationsBuilderExtension
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        Task.Run(async () =>
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var dbContext = serviceScope.ServiceProvider
                .GetService<AscendForumDbContext>();

            if (dbContext == null)
                throw new Exception("AscendForumDbContext is not configured.");

            dbContext.Database.Migrate();

            await SeedAdministrator(serviceScope.ServiceProvider, dbContext);
            await dbContext.SaveChangesAsync();
        });

        return app;
    }

    private static async Task SeedAdministrator(IServiceProvider serviceProvider, AscendForumDbContext dbContext)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        var adminRoleExists = await roleManager
            .RoleExistsAsync(RoleType.Administrator);

        if (!adminRoleExists)
            await roleManager.CreateAsync(new IdentityRole(RoleType.Administrator));

        var adminEmail = "admin@abv.bg";
        var adminPassword = "admin123";

        var user = new User()
        {
            Email = adminEmail,
            UserName = adminEmail,
            FirstName = "Admin",
            LastName = "Adminchev",
            AscendName = "SuperAdminUser"
        };

        await userManager.CreateAsync(user, adminPassword);
        await userManager.AddToRoleAsync(user, RoleType.Administrator);
    }
}