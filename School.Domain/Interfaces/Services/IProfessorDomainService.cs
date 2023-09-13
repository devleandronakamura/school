using School.Domain.Entities;

namespace School.Domain.Interfaces.Services;

public interface IProfessorDomainService : IDisposable
{
    Task<ResultResponse<Professor>> AddProfessorAsync(Professor professor);
    Task<IEnumerable<Professor>> GetAllAsync();
    Task<Professor?> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Professor professor);
    Task<ResultResponse<Professor>> UpdateAsync(Professor professor);
}