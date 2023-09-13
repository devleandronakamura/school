namespace School.Application.InputModels;

public class EditUserInputModel
{
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Roles { get; set; }
    public bool IsActive { get; set; }
}