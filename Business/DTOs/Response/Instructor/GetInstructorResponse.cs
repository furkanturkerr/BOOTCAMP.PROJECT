namespace Business.DTOs.Response.Instructor;

public class GetInstructorResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedDate { get; set; }
}