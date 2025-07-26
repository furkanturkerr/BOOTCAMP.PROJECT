using Core.DataAccess;
using Core.Entities;

namespace Repositories.Abstracts;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
}
