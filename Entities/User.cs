using Core.Entities;

namespace Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string NationalityIdentity { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
}