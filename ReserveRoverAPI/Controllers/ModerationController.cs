using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Enums;
using ReserveRoverBLL.Services.Abstract;

namespace ReserveRoverAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModerationController : ControllerBase
{
    private readonly IModerationService _moderationService;
    
    public ModerationController(IModerationService moderationService)
    {
        _moderationService = moderationService;
    }
    
    // [Authorize(Roles = "Admin")]
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ModerationResponse>>> ModerationsSearch([FromQuery] GetModerationsRequest request)
    {
        try
        {
            var results = await _moderationService.ModerationsSearch(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [Authorize(Roles = UserRoles.Moderator)]
    [HttpGet("placesSearch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ModerationPlaceSearchResponse>>> PlacesSearch([FromQuery] ModerationPlaceSearchRequest request)
    {
        try
        {
            var results = await _moderationService.PlacesSearch(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [Authorize(Roles = UserRoles.Moderator)]
    [HttpPost("updatePlaceStatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdatePlaceStatus(UpdatePlaceModerationStatusRequest request)
    {
        try
        {
            await _moderationService.UpdateModerationStatus(request, HttpContext);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
}