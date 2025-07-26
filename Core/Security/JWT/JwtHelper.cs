using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;

namespace Core.Security.JWT;

public class JwtHelper : ITokenHelper
{
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;

    public JwtHelper(IConfiguration configuration)
    {
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public AccessToken CreateToken(UserRoleMapping userRole, List<Role> roles)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var jwt = CreateJwtSecurityToken(_tokenOptions, userRole, signingCredentials, roles);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }

    private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserRoleMapping userRole,
        SigningCredentials signingCredentials, List<Role> roles)
    {
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(userRole, roles),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(UserRoleMapping userRole, List<Role> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userRole.Id.ToString()),
            new Claim(ClaimTypes.Email, userRole.User.Email),
            new Claim(ClaimTypes.Name, $"{userRole.User.FirstName} {userRole.User.LastName}")
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
        return claims;
    }
}