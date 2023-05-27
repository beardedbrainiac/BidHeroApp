using BidHeroApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BidHeroApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<ApplicationDbContext>();

            if (context != null)
            {
                string[] roles = new string[] { "Owner" ,"Administrator", "User" };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        var newRole = new IdentityRole(role);
                        newRole.NormalizedName = role.ToUpper();
                        roleStore.CreateAsync(newRole).GetAwaiter().GetResult();
                    }
                }
            }

            return services;
        }
    }
}
