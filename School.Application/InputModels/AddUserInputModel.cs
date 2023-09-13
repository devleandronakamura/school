using School.Domain.Enums;

namespace School.Application.InputModels;

public class AddUserInputModel
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public EAccess Acccess { get; set; }
}