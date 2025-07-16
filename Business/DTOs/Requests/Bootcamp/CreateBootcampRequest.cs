namespace Business.DTOs.Requests.Bootcamp;

public class CreateBootcampRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}