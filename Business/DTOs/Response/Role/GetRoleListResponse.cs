namespace Business.DTOs.Response.Role;

public class GetRoleListResponse
{
    public List<GetRoleResponse> Roles { get; set; }
    public int TotalCount { get; set; }
}