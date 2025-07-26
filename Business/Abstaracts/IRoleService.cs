using Business.DTOs.Requests.Role;
using Business.DTOs.Response.Role;

namespace Business.Abstaracts;

public interface IRoleService
{
    Task<GetRoleListResponse> GetAllAsync();
    Task<GetRoleResponse> GetByIdAsync(int id);
    Task AddAsync(CreateRoleRequest request);
    Task UpdateAsync(UpdateRoleRequest request);
    Task DeleteAsync(int id);
}
