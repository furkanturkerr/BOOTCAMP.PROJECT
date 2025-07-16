namespace Business.DTOs.Requests.Instructor;

public class CreateInstructorRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CompanyName { get; set; }

}