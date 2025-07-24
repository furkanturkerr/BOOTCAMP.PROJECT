using Business.DTOs.Requests.User;
using Business.DTOs.Response.User;

namespace Business.Abstracts;

public interface IUserService
{
    Task<List<GetUserResponse>> GetAllAsync();
    Task<GetUserResponse> GetByIdAsync(int id);
    Task<GetUserResponse> GetByEmailAsync(string email);
    Task<GetUserResponse> AddAsync(CreateUserRequest request);
    Task<GetUserResponse> UpdateAsync(int id, CreateUserRequest request);
    Task DeleteAsync(int id);
}