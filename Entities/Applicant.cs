using Core.Entities;

namespace Entities;

public class Applicant : BaseEntity
{
    public string About { get; set; }
    
    public virtual ICollection<Application> Applications { get; set; }
}