using School.Domain.Entities;

namespace School.Domain.Interfaces.Services;

public interface IUserDomainService : IDisposable
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAndPasswordAsync(string email, string password);
    Task<ResultResponse<User>> AddUserAsync(User user);
    Task<ResultResponse<User>> UpdateAsync(User user);
    Task<bool> DeleteAsync(User user);
}