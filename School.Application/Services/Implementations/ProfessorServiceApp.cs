using School.Application.InputModels;
using School.Application.Mappers;
using School.Application.Services.Interfaces;
using School.Domain.Entities;
using School.Domain.Enums;
using School.Domain.Interfaces.Services;

namespace School.Application.Services.Implementations;

public class ProfessorServiceApp : IProfessorServiceApp
{
    private readonly IProfessorDomainService _domain;

    public ProfessorServiceApp(IProfessorDomainService domain)
    {
        _domain = domain;
    }

    public async Task<IEnumerable<Professor>> GetAllAsync()
    {
        return await _domain.GetAllAsync();
    }

    public async Task<ResultResponse<Professor>> AddProfessorAsync(AddProfessorInputModel addProfessorVM)
    {
        var professor = ProfessorMapper.ToProfessor(addProfessorVM);

        return await _domain.AddProfessorAsync(professor);
    }

    public async Task<ResultResponse<Professor>> EditProfessorAsync(Guid id, EditProfessorInputModel editProfessorVM)
    {
        var professor = await _domain.GetByIdAsync(id);

        if (professor is null)
            return new ResultResponse<Professor>() { StatusCode = EStatusCode.NotFound, ErrorMessage = $"Professor com id: {id} não encontrado." };

        professor.Update(editProfessorVM.Name, editProfessorVM.DocumentNumber, editProfessorVM.IsActive, editProfessorVM.ContractType);

        return await _domain.UpdateAsync(professor);

        //return new ResultResponse<Professor>() { StatusCode = EStatusCode.Ok, Data = professor };
    }

    public async Task<ResultResponse<Professor>> GetByIdAsync(Guid id)
    {
        var professor = await _domain.GetByIdAsync(id);

        if (professor is null)
            return new ResultResponse<Professor>() { StatusCode = EStatusCode.NotFound, ErrorMessage = $"Professor com id: {id} não encontrado." };

        return new ResultResponse<Professor>() { StatusCode = EStatusCode.Ok, Data = professor };
    }

    public async Task<ResultResponse<Professor>> DeleteByIdAsync(Guid id)
    {
        var professor = await _domain.GetByIdAsync(id);

        if (professor is null)
            return new ResultResponse<Professor>() { StatusCode = EStatusCode.NotFound, ErrorMessage = $"Professor com id: {id} não encontrado." };

        professor.Delete();

        await _domain.DeleteAsync(professor);

        return new ResultResponse<Professor>() { StatusCode = EStatusCode.Ok, Data = professor };
    }
}
