using AttendanceApi.Core.Dtos.LoginUser;
using AttendanceApi.Core.Dtos.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Service.Contract
{
    public interface IUserService
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> CheckEmailExistAsync(string email);

    }
}
