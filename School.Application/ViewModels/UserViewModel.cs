namespace School.Application.ViewModels;

public class UserViewModel
{
    /// <summary>
    /// Id
    /// </summary>
    /// <example>9495d9da-33be-4634-a67e-22eced59274d</example>
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public int Access { get; set; }
    public string Roles { get; set; }

    /// <summary>
    /// IsActive
    /// </summary>
    /// <example>true</example>
    public bool IsActive { get; set; }
}
