using Business.DTOs.Requests.Auth;
using Business.DTOs.Response.Auth;
using LoginRequest = Microsoft.AspNetCore.Identity.Data.LoginRequest;
using RegisterRequest = Microsoft.AspNetCore.Identity.Data.RegisterRequest;

namespace Business.Abstaracts;

public interface IAuthService
{
    Task<TokenResponse> LoginAsync(DTOs.Requests.Auth.LoginRequest request);
    Task<TokenResponse> RegisterAsync(DTOs.Requests.Auth.RegisterRequest request);
}