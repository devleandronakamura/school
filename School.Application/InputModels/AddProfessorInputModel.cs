using School.Domain.Enums;

namespace School.Application.InputModels;

public class AddProfessorInputModel
{
    /// <summary>
    /// Name
    /// </summary>
    /// <example>Severo Snape</example>
    public string? Name { get; set; }

    /// <summary>
    /// DocumentNumber
    /// </summary>
    /// <example>111.222.333-44</example>
    public string? DocumentNumber { get; set; }

    /// <summary>
    /// ContractType
    /// </summary>
    /// <example>(1 - PartTime, 2 - FullTime, 3 - Temporary)</example>
    public EContractType ContractType { get; set; }

    /// <summary>
    /// Subjects
    /// </summary>
    /// <example>Subjects Guids</example>
    public IEnumerable<Guid>? Subjects { get; set; }
}