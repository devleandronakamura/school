using School.Domain.Entities;
using School.Domain.Interfaces.Repositories;
using School.Domain.Interfaces.Services;

namespace School.Domain.Services;

public class UserDomainService : IUserDomainService
{
    private bool _disposed = false;
    private readonly IUserRepository<User> _repository;

    public UserDomainService(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _repository.GetAllUserAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _repository.GetUserByIdAsync(id);
    }

    public async Task<ResultResponse<User>> AddUserAsync(User user)
    {
        var resultResponse = new ResultResponse<User>();

        var emailExists = await _repository.HasUserByEmailAsync(user.Email);

        if (!emailExists)
        {
            await _repository.AddUserAsync(user);
            resultResponse.Data = user;
            resultResponse.StatusCode = Enums.EStatusCode.Ok;
        }
        else
        {
            resultResponse.ErrorMessage = $"O e-mail ({user.Email}) já existe no banco de dados.";
            resultResponse.StatusCode = Enums.EStatusCode.BadRequest;
        }
        

        return resultResponse;
    }

    public async Task<ResultResponse<User>> UpdateAsync(User user)
    {
        var resultResponse = new ResultResponse<User>();

        await _repository.UpdateUserAsync(user);
        resultResponse.Data = user;
        resultResponse.StatusCode = Enums.EStatusCode.Ok;

        return resultResponse;
    }

    public async Task<bool> DeleteAsync(User user)
    {
        return await _repository.UpdateUserAsync(user);
    }

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

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
    {
        return await _repository.GetUserByEmailAndPasswordAsync(email, password);
    }
}