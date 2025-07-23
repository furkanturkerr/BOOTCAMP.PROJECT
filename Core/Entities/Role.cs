using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class Role : IdentityRole<int>
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}