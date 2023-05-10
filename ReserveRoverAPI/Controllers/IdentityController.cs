using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.Enums;
using ReserveRoverBLL.Services.Abstract;

namespace ReserveRoverAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;


    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    [AllowAnonymous]
    [HttpPost("registerManager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> RegisterManager(RegisterUserRequest request)
    {
        try
        {
            var result = await _identityService.RegisterUser(request, UserRoles.Manager);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost("registerModerator")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> RegisterModerator(RegisterUserRequest request)
    {
        try
        {
            var result = await _identityService.RegisterUser(request, UserRoles.Moderator);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost("registerAdmin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> RegisterAdmin(RegisterUserRequest request)
    {
        try
        {
            var result = await _identityService.RegisterUser(request, UserRoles.Admin);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}