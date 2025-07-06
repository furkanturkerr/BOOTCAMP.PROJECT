using Core.Entities;

namespace Entities;

public class Blacklist : BaseEntity
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }
    public bool IsActive { get; set; }  
    
    public Applicant Applicant { get; set; }
}
