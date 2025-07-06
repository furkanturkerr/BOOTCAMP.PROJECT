using Core.Entities;

namespace Entities;

public class Application : BaseEntity
{
    public int Id { get; set; }
    public int ApplicantId  { get; set; }
    public int BootcampId  { get; set; }
    public ApplicationState ApplicationState { get; set; }
    
    public Bootcamp Bootcamp { get; set; }
    public Applicant Applicant { get; set; }
}