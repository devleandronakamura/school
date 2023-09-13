using Microsoft.AspNetCore.Mvc;
using School.Application.InputModels;
using School.Application.Mappers;
using School.Application.Services.Interfaces;
using School.Application.ViewModels;
using School.Domain.Enums;

namespace School.API.Controllers.V1;

[Route(WebConstants.UserRouteName)]
[ApiController]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserServiceApp _userServiceApp;

    public UserController(ILogger<UserController> logger, IUserServiceApp userServiceApp)
    {
        _logger = logger;
        _userServiceApp = userServiceApp;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Try to get all users");
            var users = await _userServiceApp.GetAllAsync();

            return Ok(UserMapper.ToUsersVM(users));
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to get all users. Details {0}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:guid}", Name = "GetUserById")]
    public async Task<ActionResult<UserViewModel>> GetAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Try to get user by Id={0}", id);
            var resultResponse = await _userServiceApp.GetByIdAsync(id);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return Ok(UserMapper.ToUserViewModel(resultResponse.Data));
            else
                return NotFound(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to get user by Id={0}. Details {1}", id, ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(AddUserInputModel addUser)
    {
        try
        {
            _logger.LogInformation("Try to add user");
            var resultResponse = await _userServiceApp.AddUserAsync(addUser);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return new CreatedAtRouteResult("GetUserById", new { id = resultResponse.Data.Id }, UserMapper.ToUserViewModel(resultResponse.Data));
            else
                return BadRequest(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to add user. Details {0}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Try to delete user by Id={0}", id);
            var resultResponse = await _userServiceApp.DeleteByIdAsync(id);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return Ok(UserMapper.ToUserViewModel(resultResponse.Data));
            else
                return NotFound(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to delete user by Id={0}. Details {1}", id, ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> PutAsync(Guid id, EditUserInputModel editUserVM)
    {
        try
        {
            _logger.LogInformation("Try to edit professor by Id={0}", id);
            var resultResponse = await _userServiceApp.EditUserAsync(id, editUserVM);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return Ok(UserMapper.ToUserViewModel(resultResponse.Data));
            else
                return NotFound(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to edit professor by Id={0}. Details {1}", id, ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("login")]
    public async Task<IActionResult> Login(LoginUserInputModel loginUser)
    {
        try
        {
            _logger.LogInformation("Try to get user by Email={0} and Password={1}", loginUser.Email, loginUser.Password);
            var resultResponse = await _userServiceApp.GetByEmailAndPasswordAsync(loginUser);

            if (resultResponse.StatusCode == EStatusCode.Ok)
                return Ok(resultResponse.Data);
            else
                return NotFound(resultResponse.ErrorMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error to get user Email={0} and Password={1}. Details {2}", loginUser.Email, loginUser.Password, ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
