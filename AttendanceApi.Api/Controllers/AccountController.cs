using AttendanceApi.Core.Dtos.LoginUser;
using AttendanceApi.Core.Dtos.RegisterUser;
using AttendanceApi.Core.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var result= await userService.LoginAsync(loginDto);
            if(result is null) return Unauthorized();
            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var result= await userService.RegisterAsync(registerDto);
            if(result is null) return BadRequest();
            return Ok(result);
        }
    }
}
