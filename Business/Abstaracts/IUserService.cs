using Business.DTOs.Requests.User;

namespace Business.Abstaracts;

public interface IUserService
{
    Task GetAllAsync();
    Task GetByIdAsync(int id);
    Task UpdateAsync(UpdateUserRequest request);
    Task DeleteAsync(int id);
    Task<GetUserResponse> GetByEmailAsync(string email);
}
