using School.Application.InputModels;
using School.Application.Mappers;
using School.Application.Services.Interfaces;
using School.Application.ViewModels;
using School.Domain.Entities;
using School.Domain.Enums;
using School.Domain.Interfaces.Services;

namespace School.Application.Services.Implementations;
public class UserServiceApp : IUserServiceApp
{
    private readonly IUserDomainService _domain;
    private readonly IAuthDomainService _auth;

    public UserServiceApp(IUserDomainService domain, IAuthDomainService auth)
    {
        _domain = domain;
        _auth = auth;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _domain.GetAllAsync();
    }

    public async Task<ResultResponse<User>> GetByIdAsync(Guid id)
    {
        var user = await _domain.GetByIdAsync(id);

        if (user is null)
            return new ResultResponse<User>() { StatusCode = EStatusCode.NotFound, ErrorMessage = $"User com id: {id} não encontrado." };

        return new ResultResponse<User>() { StatusCode = EStatusCode.Ok, Data = user };
    }

    public async Task<ResultResponse<User>> DeleteByIdAsync(Guid id)
    {
        var user = await _domain.GetByIdAsync(id);

        if (user is null)
            return new ResultResponse<User>() { StatusCode = EStatusCode.NotFound, ErrorMessage = $"Professor com id: {id} não encontrado." };

        user.Delete();

        await _domain.DeleteAsync(user);

        return new ResultResponse<User>() { StatusCode = EStatusCode.Ok, Data = user };
    }

    public async Task<ResultResponse<User>> AddUserAsync(AddUserInputModel addUser)
    {
        var passwordHash = _auth.ComputeSha256Hash(addUser.Password);
        addUser.Password = passwordHash;

        var user = UserMapper.ToUser(addUser);

        return await _domain.AddUserAsync(user);
    }

    public async Task<ResultResponse<User>> EditUserAsync(Guid id, EditUserInputModel editUserVM)
    {
        var user = await _domain.GetByIdAsync(id);

        if (user is null)
            return new ResultResponse<User>() { StatusCode = EStatusCode.NotFound, ErrorMessage = $"Usuário com id: {id} não encontrado." };

        user.Update(password: editUserVM.Password, roles: editUserVM.Roles, isActive: editUserVM.IsActive);

        return await _domain.UpdateAsync(user);

        //return new ResultResponse<Professor>() { StatusCode = EStatusCode.Ok, Data = professor };
    }

    public async Task<ResultResponse<LoginUserViewModel>> GetByEmailAndPasswordAsync(LoginUserInputModel loginUser)
    {
        var passwordHash = _auth.ComputeSha256Hash(loginUser.Password);

        var user = await _domain.GetByEmailAndPasswordAsync(loginUser.Email, passwordHash);

        if (user is null)
            return new ResultResponse<LoginUserViewModel>() { StatusCode = EStatusCode.NotFound, ErrorMessage = $"Usuário e senha não encontrado." };

        var token = _auth.GenerateJwtToken(user.Email, user.Roles);

        var loginUserVM = new LoginUserViewModel(user.Email, token);

        return new ResultResponse<LoginUserViewModel>() { StatusCode = EStatusCode.Ok, Data = loginUserVM };
    }
}
