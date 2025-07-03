using AttendanceApi.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Identity
{
    public static class IdentitySeed
    {
        public async static Task SeedIdentityAsync(UserManager<AppUser> userManager)
        {
            if (userManager.Users.Count() == 0)
            {

                var user = new AppUser()
                {
                    Email = "alimohamed@gmail.com",
                    DisplayName = "Ali Mohamed",
                    PhoneNumber= "1234567890",
                    UserName="ali.mohamed",
                   

                };
                

            await userManager.CreateAsync(user, "P@ssW0rd");
            }

        }
    }
}
