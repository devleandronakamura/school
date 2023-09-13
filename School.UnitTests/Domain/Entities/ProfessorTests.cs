using School.Domain.Entities;
using School.Domain.Enums;
using System.Linq;
using Xunit;

namespace School.UnitTests.Domain.Entities;

public class ProfessorTests
{
    [Fact]
    public void TestIfProfessorIsActive()
    {
        var nameExpected = "Leandro";
        var professor = new Professor(nameExpected, "123.456.789-00", ContractType.Temporary);

        Assert.True(professor.IsActive);
        Assert.NotNull(professor.DocumentNumber);
        Assert.Equal(nameExpected, professor.Name);
        Assert.False(professor.Subjects.Any());
    }
}
