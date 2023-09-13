namespace School.Domain.Interfaces.Services;

public interface IAuthDomainService
{
    string GenerateJwtToken(string email, string role);
    string ComputeSha256Hash(string password);
}
