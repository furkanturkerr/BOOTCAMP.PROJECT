using Entities;

namespace Business.DTOs.Requests.Application;

public class CreateApplicationRequest
{
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public ApplicationState State { get; set; }
}