using Microsoft.AspNetCore.Identity;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Data
{
    public static class SeedData
    {
        public async static Task Seed(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private async static Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if(await userManager.FindByEmailAsync("algirdas.vasi@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "algirdas.vasi@gmail.com",
                    Email = "algirdas.vasi@gmail.com",
                    VartotojasId = 1
                };
                var result = await userManager.CreateAsync(user, "P$ssword1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }

            if (await userManager.FindByEmailAsync("user@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",
                    VartotojasId = 2
                };
                var result = await userManager.CreateAsync(user, "P$ssword1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }

            if (await userManager.FindByEmailAsync("specialist@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "specialist@gmail.com",
                    Email = "specialist@gmail.com",
                    VartotojasId = 3
                };
                var result = await userManager.CreateAsync(user, "P$ssword1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Specialist");
                }
            }          
        }

        private async static Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync("Administrator"))
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync("Specialist"))
            {
                var role = new IdentityRole
                {
                    Name = "Specialist"
                };
                await roleManager.CreateAsync(role);
            }
        }
    }
}
