using Entities;

namespace Business.DTOs.Response.Application;

public class GetApplicationResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string ApplicantName { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public ApplicationState State { get; set; }
    public DateTime CreatedDate { get; set; }
}