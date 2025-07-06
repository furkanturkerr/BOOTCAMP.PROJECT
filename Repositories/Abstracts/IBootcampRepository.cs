using Entities;

namespace Repositories.Abstracts;

public interface IBootcampRepository : IGenericRepository<Bootcamp>
{
    Task<IEnumerable<Bootcamp>> GetBootcampsByInstructorAsync(int instructorId);
}