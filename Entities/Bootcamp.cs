namespace Entities;

public class Bootcamp
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId  { get; set; }
    public DateTime StartDate  { get; set; }
    public DateTime EndDate  { get; set; }
    public BootcampState BootcampState { get; set; }
    
    public virtual Instructor Instructor { get; set; }
    public virtual List<Application> Applications { get; set; }
}