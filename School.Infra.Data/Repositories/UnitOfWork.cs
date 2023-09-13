using School.Infra.Data.Context;
using School.Infra.Data.Interfaces;

namespace School.Infra.Data.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    //private ProfessorRepository _professorRepository;
    public SchoolDbContext _context;

    public UnitOfWork(SchoolDbContext context)
    {
        _context = context;
    }

    //public IProfessorRepository ProfessorRepository
    //{
    //    get
    //    {
    //        return _professorRepository = _professorRepository ?? new ProfessorRepository(_context);
    //    }
    //}

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
