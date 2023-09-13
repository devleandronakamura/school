using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Interfaces.Repositories;
using School.Infra.Data.Context;

namespace School.Infra.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository<User>
{
    public UserRepository(SchoolDbContext context) : base(context)
    { }

    public async Task<IEnumerable<User>> GetAllUserAsync()
    {
        return await GetAll().Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await GetByExpresssionAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<bool> HasUserByEmailAsync(string email)
    {
        return await GetByExpresssionAsync(x => x.Email == email && !x.IsDeleted) != null ? true : false;
    }

    public async Task<User> AddUserAsync(User user)
    {
        await AddAsync(user);

        return user;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        await UpdateAsync(user);
        return true;
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return await GetByExpresssionAsync(x => x.Email == email && x.Password == password && !x.IsDeleted);
    }
}
