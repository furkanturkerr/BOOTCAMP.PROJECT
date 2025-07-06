namespace Entities;

public class Blacklist
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set;}
    public int ApplicantId  { get; set; }
    
    public Applicant Applicant { get; set; }
}