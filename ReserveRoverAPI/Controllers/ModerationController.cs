using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
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
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ModerationResponse>>> Get([FromQuery] GetModerationsRequest request)
    {
        try
        {
            var results = await _moderationService.GetModerations(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    // [Authorize(Roles = "Moderator")]
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
    
    // [Authorize(Roles = "Moderator")]
    [HttpPost("updatePlaceStatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdatePlaceStatus(int placeId, short moderationStatus)
    {
        try
        {
            await _moderationService.UpdateModerationStatus(placeId, moderationStatus, HttpContext);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
}