using School.Application.InputModels;
using School.Application.ViewModels;
using School.Domain.Entities;

namespace School.Application.Mappers;

public static class ProfessorMapper
{
    public static Professor ToProfessor(AddProfessorInputModel addProfessor)
    {
        return new Professor(name: addProfessor.Name, documentNumber: addProfessor.DocumentNumber, contractType: addProfessor.ContractType);
    }

    public static ProfessorViewModel ToProfessorVM(Professor? professor)
    {
        return new ProfessorViewModel()
        {
            Id = professor.Id,
            Name = professor.Name,
            DocumentNumber = professor.DocumentNumber,
            ContractType = professor.ContractType,
            ContractTypeDescription = professor.ContractType.ToString(),
            IsActive = professor.IsActive,
            Subjects = professor.Subjects
        };
    }

    public static List<ProfessorViewModel> ToProfessorsVM(IEnumerable<Professor> professors)
    {
        var professorsVM = new List<ProfessorViewModel>();

        foreach (var professor in professors)
        {
            professorsVM.Add(new ProfessorViewModel()
            {
                Id = professor.Id,
                Name = professor.Name,
                DocumentNumber = professor.DocumentNumber,
                ContractType = professor.ContractType,
                ContractTypeDescription = professor.ContractType.ToString(),
                IsActive = professor.IsActive
            });
        }

        return professorsVM;
    }
}
