using System.ComponentModel.DataAnnotations;
using Entities;

namespace Core.Entities;
public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalityIdentity { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    
    public virtual ICollection<UserRoleMapping> UserRoles { get; set; }


}

