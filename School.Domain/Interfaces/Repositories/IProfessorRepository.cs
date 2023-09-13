using School.Domain.Entities;

namespace School.Domain.Interfaces.Repositories;

public interface IProfessorRepository<T> : IRepository<T> where T : class
{
    Task<Professor> AddProfessorAsync(Professor professor);
    Task<IEnumerable<Professor>> GetAllProfessorAsync();
    Task<Professor?> GetProfessorByIdAsync(Guid id);
    Task<bool> UpdateProfessorAsync(Professor professor);
    Task<Professor?> GetProfessorByDocumentNumberAsync(string? documentNumber);
}