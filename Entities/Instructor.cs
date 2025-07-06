using Core.Entities;

namespace Entities;

public class Instructor : BaseEntity
{
    public string CompanyName { get; set; }
    public virtual ICollection<Bootcamp> Bootcamps { get; set; }
}