using Business.DTOs.Requests.Auth;
using Business.DTOs.Response.Auth;

namespace Business.Abstaracts;

public interface IAuthService
{
    Task<TokenResponse> LoginAsync(LoginRequest request);
    Task<TokenResponse> RegisterAsync(RegisterRequest request);
}