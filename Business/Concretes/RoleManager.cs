using Business.Abstaracts;
using Business.DTOs.Requests.Role;
using Business.DTOs.Response.Role;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class RoleManager : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleManager(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<GetRoleListResponse> GetAllAsync()
    {
        var roles = await _roleRepository.GetAllAsync();

        var response = new GetRoleListResponse
        {
            Roles = roles.Select(r => new GetRoleResponse
            {
                Id = r.Id,
                Name = r.Name
            }).ToList(),
            TotalCount = roles.Count()
        };

        return response;
    }

    public async Task<GetRoleResponse> GetByIdAsync(int id)
    {
        var role = await _roleRepository.GetAsync(r => r.Id == id, null);
        
        if (role == null)
            throw new Exception("Rol bulunamadı");

        return new GetRoleResponse
        {
            Id = role.Id,
            Name = role.Name
        };
    }

    public async Task AddAsync(CreateRoleRequest request)
    {
        var isRoleExists = await _roleRepository.GetAsync(r => r.Name == request.Name, null);
        if (isRoleExists != null)
            throw new Exception("Bu rol adı zaten kullanılıyor");

        var role = new Role
        {
            Name = request.Name
        };

        await _roleRepository.AddAsync(role);
    }

    public async Task UpdateAsync(UpdateRoleRequest request)
    {
        var role = await _roleRepository.GetAsync(r => r.Id == request.Id, null);
        
        if (role == null)
            throw new Exception("Rol bulunamadı");

        var isRoleExists = await _roleRepository.GetAsync(r => r.Name == request.Name && r.Id != request.Id, null);
        if (isRoleExists != null)
            throw new Exception("Bu rol adı zaten kullanılıyor");

        role.Name = request.Name;
        await _roleRepository.UpdateAsync(role);
    }

    public async Task DeleteAsync(int id)
    {
        var role = await _roleRepository.GetAsync(r => r.Id == id, null);
        
        if (role == null)
            throw new Exception("Rol bulunamadı");

        await _roleRepository.DeleteAsync(role);
    }
}
