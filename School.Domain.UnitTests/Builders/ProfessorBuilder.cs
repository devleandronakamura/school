using School.Domain.Entities;
using School.Domain.Enums;
using System.Runtime.CompilerServices;

namespace School.Domain.UnitTests.Builders;

public class ProfessorBuilder
{
    private string _name = "Leandro";
    private readonly string _document = "123.456.789-00";
    private readonly EContractType _contract  = EContractType.Temporary;

    public static ProfessorBuilder New()
    {
        return new ProfessorBuilder();
    }

    public ProfessorBuilder WithName(string name)
    {
        _name = name;
        return this;    
    }

    public Professor Build()
    {
        return new Professor(_name, _document, _contract);
    }
}
