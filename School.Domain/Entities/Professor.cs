using School.Domain.Enums;

namespace School.Domain.Entities;

public class Professor : EntityBase
{
    public Professor(string? name, string? documentNumber, EContractType contractType)
    {
        Created = DateTime.Now;
        IsActive = true;
        Name = name;
        DocumentNumber = documentNumber;
        ContractType = contractType;
        Subjects = new List<Subject>();
    }

    public string? Name { get; set; }
    public string? DocumentNumber { get; set; }
    public EContractType ContractType { get; set; }
    public IEnumerable<Subject> Subjects { get; set; }

    public void Update(string? name, string? documentNumber, bool isActive, EContractType contractType)
    {
        LastUpdate = DateTime.Now;
        Name = name;
        DocumentNumber = documentNumber;
        IsActive = isActive;
        ContractType = contractType;
    }
}