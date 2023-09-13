using School.Domain.Enums;

namespace School.Domain.Entities;

public class User : EntityBase
{
    public User(string fullName, string email, string password, EAccess access)
    {
        Created = DateTime.Now;
        IsActive = true;
        FullName = fullName;
        Email = email;
        Password = password;
        Access = access;
        Roles = access.ToString();
    }

    public string FullName { get; private set; }
    public string Email { get; set; }
    public string Password { get; private set; }
    public EAccess Access { get; private set; }
    public string Roles { get; private set; }

    public void Update(string password, string roles, bool isActive)
    {
        LastUpdate = DateTime.Now;
        Password = password;
        Roles = roles;
        IsActive = isActive;
    }
}
