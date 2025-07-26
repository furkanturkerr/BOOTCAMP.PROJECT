namespace Business.DTOs.Requests.User;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalityIdentity { get; set; }

}