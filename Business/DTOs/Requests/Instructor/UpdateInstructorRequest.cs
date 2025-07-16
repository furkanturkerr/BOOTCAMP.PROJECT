namespace Business.DTOs.Requests.Instructor;

public class UpdateInstructorRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
 
}