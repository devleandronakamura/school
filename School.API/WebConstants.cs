using School.Domain.Enums;

namespace School.API;

public static class WebConstants
{
    public const string ProfessorRouteName = "api/professors";
    public const string UserRouteName = "api/users";
    public const string ItemRouteName = "api/v{version:apiVersion}/items";
    public const string ProtocolRouteName = "api/v{version:apiVersion}/protocols";
    public const string Both = nameof(EAccess.Administrator) + ", " + nameof(EAccess.User);
    public const string User = nameof(EAccess.User);
    public const string Admin = nameof(EAccess.Administrator);
}