using School.Domain.Entities;
using School.Domain.Enums;
using School.Domain.UnitTests.Builders;
using Xunit;

namespace Tests.School.Domain.UnitTests.Entities;

public class ProfessorTests
{
    [Fact]
    public void TestIfProfessorIsActive()
    {
        var expectedName = "Leandro";
        var professor = ProfessorBuilder.New().WithName(expectedName).Build();

        Assert.True(professor.IsActive);
        Assert.NotNull(professor.DocumentNumber);
        Assert.Equal(expectedName, professor.Name);
        Assert.False(professor.Subjects.Any());
    }
}
