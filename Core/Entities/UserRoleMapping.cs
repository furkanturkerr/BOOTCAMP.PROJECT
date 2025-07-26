using Core.Entities;

namespace Entities;

public class UserRoleMapping : BaseEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    
    public virtual User User { get; set; }
    public virtual GetRoleResponse Role { get; set; }

}