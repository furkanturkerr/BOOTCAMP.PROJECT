using Business.Abstaracts;
using Business.Abstracts;
using Business.DTOs.Requests.Auth;
using Business.DTOs.Requests.User;
using Business.DTOs.Response.Auth;
using Core.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Entities;
using Repositories.Contexts;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly BaseDbContext _context; // direkt context ile rol mapping

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, BaseDbContext context)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _context = context;
    }

    public async Task<TokenResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userService.GetByEmailAsync(request.Email);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            throw new Exception("Parola hatalı");

        // UserRoles mutlaka dolu gelmeli
        var roles = _context.UserRoles
            .Where(x => x.UserId == user.Id)
            .Select(x => x.Role)
            .ToList();

        if (!roles.Any())
            throw new Exception("Kullanıcıya rol atanmadı");

        var token = _tokenHelper.CreateToken(user, roles);
        return new TokenResponse
        {
            Token = token.Token,
            Expiration = token.Expiration
        };
    }

    public async Task<TokenResponse> RegisterAsync(RegisterRequest request)
    {
        var exists = await _userService.GetByEmailAsync(request.Email);
        if (exists != null)
            throw new Exception("Bu email adresi zaten kayıtlı");

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        var createUserRequest = new CreateUserRequest
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            DateOfBirth = DateTime.Now,
            NationalityIdentity = "00000000000",
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        var newUser = await _userService.AddAsync(createUserRequest);

        // Register sırasında verilen rolü ekle
        var roleId = (int)request.Role;
        var roleEntity = _context.Roles.FirstOrDefault(r => r.Id == roleId);
        if (roleEntity == null)
            throw new Exception("Rol bulunamadı");

        // UserRole kaydı ekle
        var mapping = new UserRoleMapping
        {
            UserId = newUser.Id,
            RoleId = roleId
        };
        _context.UserRoles.Add(mapping);
        await _context.SaveChangesAsync();

        var roles = new List<Role> { roleEntity };

        var token = _tokenHelper.CreateToken(newUser, roles);
        return new TokenResponse
        {
            Token = token.Token,
            Expiration = token.Expiration
        };
    }
}
