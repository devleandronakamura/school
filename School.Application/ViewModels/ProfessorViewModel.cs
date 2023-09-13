using School.Domain.Entities;
using School.Domain.Enums;

namespace School.Application.ViewModels;

public class ProfessorViewModel
{
    /// <summary>
    /// Id
    /// </summary>
    /// <example>9495d9da-33be-4634-a67e-22eced59274d</example>
    public Guid Id { get; set; }

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
    /// ContractType
    /// </summary>
    /// <example>(1 - PartTime, 2 - FullTime, 3 - Temporary)</example>
    public string? ContractTypeDescription { get; set; }

    /// <summary>
    /// IsActive
    /// </summary>
    /// <example>true</example>
    public bool IsActive { get; set; }

    /// <summary>
    /// Subjects
    /// </summary>
    /// <example>Subjects Guids</example>
    public IEnumerable<Subject>? Subjects { get; set; }
}