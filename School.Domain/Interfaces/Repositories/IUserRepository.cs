using School.Domain.Entities;

namespace School.Domain.Interfaces.Repositories;

public interface IUserRepository<T> : IRepository<T> where T : class
{
    Task<IEnumerable<User>> GetAllUserAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
    Task<User> AddUserAsync(User user);
    Task<bool> HasUserByEmailAsync(string email);
    Task<bool> UpdateUserAsync(User user);
}