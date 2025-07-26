namespace Business.DTOs.Response.User;

public class GetUserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalityIdentity { get; set; }
    public List<string> Roles { get; set; }
}