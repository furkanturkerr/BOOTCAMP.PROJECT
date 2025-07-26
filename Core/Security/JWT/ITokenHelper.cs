using Core.Entities;
using Entities;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(UserRoleMapping user, List<Role> roles);
}
