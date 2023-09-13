using Moq;
using School.Application.Services.Implementations;
using School.Application.UnitTests.Builders;
using School.Domain.Enums;
using School.Domain.Interfaces.Services;
using School.Domain.UnitTests.Builders;
using Xunit;

namespace Tests.School.Application.UnitTests.Services;

public class ProfessorServiceAppTests : IDisposable
{
    private bool _disposed = false;
    private readonly Mock<IProfessorDomainService> _professorDomainServiceMock = new Mock<IProfessorDomainService>();


    private ProfessorServiceApp GetProfessorServiceApp()
    {
        return new ProfessorServiceApp(domain: _professorDomainServiceMock.Object);
    }

    [Fact(DisplayName = "GET: Com Id existente (Valido)")]
    public async Task GetByIdAsync_ThatExists()
    {
        //Arrange
        var expectedProfessor = ProfessorBuilder.New().Build();
        var expectedResponseCode = EStatusCode.Ok;

        _professorDomainServiceMock
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(expectedProfessor);

        var serviceMock = GetProfessorServiceApp();

        //Act
        var result = await serviceMock.GetByIdAsync(It.IsAny<Guid>());
        var responseCode = result.StatusCode;

        //Assert
        Assert.Equal(expectedResponseCode, responseCode);

        _professorDomainServiceMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        _disposed = true;
    }
}
