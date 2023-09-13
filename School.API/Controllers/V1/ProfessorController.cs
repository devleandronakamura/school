using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.InputModels;
using School.Application.Mappers;
using School.Application.Services.Interfaces;
using School.Application.ViewModels;
using School.Domain.Enums;

namespace School.API.Controllers;

[Route(WebConstants.ProfessorRouteName)]
[ApiController]
public class ProfessorController : ControllerBase
{
    private readonly ILogger<ProfessorController> _logger;
    private readonly IProfessorServiceApp _professorServiceApp;
    

    public ProfessorController(
        ILogger<ProfessorController> logger,
        IProfessorServiceApp professorServiceApp)
    {
        _logger = logger;
        _professorServiceApp = professorServiceApp;
    }

    
    [HttpGet]
    [Authorize(Roles = WebConstants.Both)]
    public async Task<ActionResult<IEnumerable<ProfessorViewModel>>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Try to get all professors");
            var professors = await _professorServiceApp.GetAllAsync();

            return Ok(ProfessorMapper.ToProfessorsVM(professors));
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to get all professors. Details {0}", ex.Message);
            return BadRequest(ex.Message);
        }
    }
    

    [HttpGet("{id:guid}", Name = "GetProfessorById")]
    [Authorize(Roles = WebConstants.Both)]
    public async Task<ActionResult<ProfessorViewModel>> GetAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Try to get professor by Id={0}", id);
            var resultResponse = await _professorServiceApp.GetByIdAsync(id);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return Ok(ProfessorMapper.ToProfessorVM(resultResponse.Data));
            else
                return NotFound(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to get professor by Id={0}. Details {1}", id, ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = WebConstants.Admin)]
    public async Task<ActionResult> PostAsync(AddProfessorInputModel addProfessor)
    {
        try
        {
            _logger.LogInformation("Try to add professor");
            var resultResponse = await _professorServiceApp.AddProfessorAsync(addProfessor);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return new CreatedAtRouteResult("GetProfessorById", new { id = resultResponse.Data.Id }, ProfessorMapper.ToProfessorVM(resultResponse.Data));
            else
                return BadRequest(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to add professor. Details {0}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = WebConstants.Admin)]
    public async Task<ActionResult> PutAsync(Guid id, EditProfessorInputModel editProfessorVM)
    {
        try
        {
            _logger.LogInformation("Try to edit professor by Id={0}", id);
            var resultResponse = await _professorServiceApp.EditProfessorAsync(id, editProfessorVM);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return Ok(ProfessorMapper.ToProfessorVM(resultResponse.Data));
            else
                return NotFound(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to edit professor by Id={0}. Details {1}", id, ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = WebConstants.Admin)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Try to delete professor by Id={0}", id);
            var resultResponse = await _professorServiceApp.DeleteByIdAsync(id);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return Ok(ProfessorMapper.ToProfessorVM(resultResponse.Data));
            else
                return NotFound(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to delete professor by Id={0}. Details {1}", id, ex.Message);
            return BadRequest(ex.Message);
        }
    }
}