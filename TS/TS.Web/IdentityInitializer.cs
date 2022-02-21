using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web
{
    public static class IdentityInitializer
    {     
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("Rukiye");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Rukiye",
                    Surname = "Asna",
                    UserName = "rukiye",
                    Email = "rukiye@gmail.com",
                    PhoneNumber = "5458412222"


                };
                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
