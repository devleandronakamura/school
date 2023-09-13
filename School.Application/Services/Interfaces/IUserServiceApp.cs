using School.Application.InputModels;
using School.Application.ViewModels;
using School.Domain.Entities;

namespace School.Application.Services.Interfaces;

public interface IUserServiceApp
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<ResultResponse<User>> GetByIdAsync(Guid id);
    Task<ResultResponse<LoginUserViewModel>> GetByEmailAndPasswordAsync(LoginUserInputModel loginUser);
    Task<ResultResponse<User>> AddUserAsync(AddUserInputModel addUser);
    Task<ResultResponse<User>> EditUserAsync(Guid id, EditUserInputModel editUserVM);
    Task<ResultResponse<User>> DeleteByIdAsync(Guid id);
}