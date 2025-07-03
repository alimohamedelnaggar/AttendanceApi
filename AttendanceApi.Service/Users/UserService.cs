using AttendanceApi.Core.Dtos.LoginUser;
using AttendanceApi.Core.Dtos.RegisterUser;
using AttendanceApi.Core.Entities.Identity;
using AttendanceApi.Core.Service.Contract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Service.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user=await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return null;
            var result =await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(!result.Succeeded) result= null;

            return new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token =null
            };
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await CheckEmailExistAsync(registerDto.Email)) return null;
            var user = new AppUser()
            {
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                DisplayName = registerDto.DisplayName,
                UserName = registerDto.Email.Split("@")[0],
            };
            var result= await userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded)return null;
            return new UserDto()
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = null
            };


        }
        public async Task<bool> CheckEmailExistAsync(string email)
        {
           return await userManager.FindByEmailAsync(email) is not null;
        }
    }
}
