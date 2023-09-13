using School.Domain.Entities;
using School.Domain.Interfaces.Repositories;
using School.Domain.Interfaces.Services;

namespace School.Domain.Services;
public class ProfessorDomainService : IProfessorDomainService
{
    private bool _disposed = false;
    private readonly IProfessorRepository<Professor> _repository;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public ProfessorDomainService(IProfessorRepository<Professor> repository)
    {
        _repository = repository;
    }

    public async Task<ResultResponse<Professor>> AddProfessorAsync(Professor professor)
    {
        var resultResponse = new ResultResponse<Professor>();

        var professorDb = await _repository.GetProfessorByDocumentNumberAsync(professor.DocumentNumber);

        if (professorDb is null)
        {
            await _repository.AddProfessorAsync(professor);
            resultResponse.Data = professor;
            resultResponse.StatusCode = Enums.EStatusCode.Ok;
        }
        else
        {
            resultResponse.ErrorMessage = $"O documentNumber={professor.DocumentNumber} já existe no banco de dados.";
            resultResponse.StatusCode = Enums.EStatusCode.BadRequest;
        }

        return resultResponse;
    }

    public async Task<IEnumerable<Professor>> GetAllAsync()
    {
        return await _repository.GetAllProfessorAsync();
    }

    public async Task<Professor?> GetByIdAsync(Guid id)
    {
        return await _repository.GetProfessorByIdAsync(id);
    }

    public async Task<bool> DeleteAsync(Professor professor)
    {
        return await _repository.UpdateProfessorAsync(professor);
    }

    public async Task<ResultResponse<Professor>> UpdateAsync(Professor professor)
    {
        var resultResponse = new ResultResponse<Professor>();

        var professorDb = await _repository.GetProfessorByDocumentNumberAsync(professor.DocumentNumber);

        var documentNumberDoesNotExist = professorDb is null;
        var documentNumberIsTheSame = professorDb != null && professorDb.Id == professor.Id;

        if (documentNumberDoesNotExist || documentNumberIsTheSame)
        {
            await _repository.UpdateProfessorAsync(professor);
            resultResponse.Data = professor;
            resultResponse.StatusCode = Enums.EStatusCode.Ok;
        }
        else
        {
            resultResponse.ErrorMessage = $"O documentNumber={professor.DocumentNumber} já existe no banco de dados.";
            resultResponse.StatusCode = Enums.EStatusCode.BadRequest;
        }

        return resultResponse;
    }
}
