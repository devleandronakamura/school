using School.Application.InputModels;
using School.Domain.Enums;

namespace School.Application.UnitTests.Builders;

public class AddProfessorInputModelBuilder
{
    private string _name = "Leandro";
    private readonly string _document = "123.456.789-00";
    private readonly EContractType _contract = EContractType.Temporary;

    public static AddProfessorInputModelBuilder New()
    {
        return new AddProfessorInputModelBuilder();
    }

    public AddProfessorInputModel Build()
    {
        return new AddProfessorInputModel()
        {
            Name = _name,
            DocumentNumber = _document,
            ContractType = _contract
        };
    }
}
