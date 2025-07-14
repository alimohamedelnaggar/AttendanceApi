using AttendanceApi.Core.Entities.Identity;
using AttendanceApi.Core.Service.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Service.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("InstructorId", user.Id),
                new Claim(ClaimTypes.GivenName,user.DisplayName),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),

            };
            var roles =await userManager.GetRolesAsync(user);

            foreach (var Role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, Role));
            }
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(double.Parse( configuration["JWT:Duration"])),
                claims:claims,
                signingCredentials:new SigningCredentials(secKey,SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
