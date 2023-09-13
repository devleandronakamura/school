using School.Application.InputModels;
using School.Domain.Entities;

namespace School.Application.Services.Interfaces;

public interface IProfessorServiceApp
{
    Task<IEnumerable<Professor>> GetAllAsync();
    Task<ResultResponse<Professor>> GetByIdAsync(Guid id);
    Task<ResultResponse<Professor>> AddProfessorAsync(AddProfessorInputModel addProfessorVM);
    Task<ResultResponse<Professor>> EditProfessorAsync(Guid id, EditProfessorInputModel editProfessorVM);
    Task<ResultResponse<Professor>> DeleteByIdAsync(Guid id);
}