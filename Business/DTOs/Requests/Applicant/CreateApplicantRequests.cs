using Entities;
namespace Business.DTOs.Requests.Applicant;

public class CreateApplicantRequests
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string About { get; set; }
}