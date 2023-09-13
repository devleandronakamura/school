using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Interfaces.Repositories;
using School.Infra.Data.Context;

namespace School.Infra.Data.Repositories;

public class ProfessorRepository : Repository<Professor>, IProfessorRepository<Professor>
{
    public ProfessorRepository(SchoolDbContext context) : base(context)
    { }

    public async Task<Professor> AddProfessorAsync(Professor professor)
    {
        await AddAsync(professor);

        return professor;
    }

    public async Task<bool> UpdateProfessorAsync(Professor professor)
    {
        await UpdateAsync(professor);
        return true;
    }

    public async Task<IEnumerable<Professor>> GetAllProfessorAsync()
    {       
        return await GetAll().Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<Professor?> GetProfessorByIdAsync(Guid id)
    {
        return await GetByExpresssionAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<Professor?> GetProfessorByDocumentNumberAsync(string? documentNumber)
    {
        return await GetByExpresssionAsync(x => x.DocumentNumber == documentNumber && !x.IsDeleted);
    }
}