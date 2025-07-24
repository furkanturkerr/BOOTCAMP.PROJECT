using Business.Abstaracts;
using Business.DTOs.Requests.Auth;
using Business.DTOs.Response.User;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Entities;
using AutoMapper;
using Business.DTOs.Requests.User;
using Business.DTOs.Response.Auth;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IMapper _mapper;
    
    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _mapper = mapper;
    }

    public async Task<TokenResponse> LoginAsync(LoginRequest request)
    {
        var userResponse = await _userService.GetByEmailAsync(request.Email);
        if (userResponse == null)
            throw new Exception("Kullanıcı bulunamadı");

        if (!HashingHelper.VerifyPasswordHash(request.Password, userResponse.PasswordHash, userResponse.PasswordSalt))
            throw new Exception("Parola hatalı");

        var user = _mapper.Map<User>(userResponse);
        var token = _tokenHelper.CreateToken(user, new List<Role>());  // Şimdilik boş rol listesi

        return new TokenResponse
        {
            AccessToken = token.Token,
            ExpirationTime = token.Expiration
        };
    }

    public async Task<TokenResponse> RegisterAsync(RegisterRequest request)
    {
        var createUserRequest = new CreateUserRequest
        {
            Email = request.Email,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var userResponse = await _userService.AddAsync(createUserRequest);
        var user = _mapper.Map<User>(userResponse);
        var token = _tokenHelper.CreateToken(user, new List<Role>());  // Şimdilik boş rol listesi

        return new TokenResponse
        {
            AccessToken = token.Token,
            ExpirationTime = token.Expiration
        };
    }
}
