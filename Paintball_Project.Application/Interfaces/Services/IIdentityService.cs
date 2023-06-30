using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;

namespace Paintball_Project.Application.Interfaces.Services;

public interface IIdentityService
{
    Task<UserLoginResponse> LoginAsync(LoginRequest loginRequest);
    Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister);
}
