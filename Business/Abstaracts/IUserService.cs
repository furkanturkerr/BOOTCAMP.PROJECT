using Business.DTOs.Response.User;
using Business.DTOs.Requests.User;
using Core.Entities;

namespace Business.Abstracts;

public interface IUserService
{
    Task<GetUserListResponse> GetAllAsync();
    Task<GetUserResponse> GetByIdAsync(int id);
    Task AddAsync(CreateUserRequest request);
    Task DeleteAsync(int id);
    Task<User?> GetByEmailAsync(string requestEmail);
}
