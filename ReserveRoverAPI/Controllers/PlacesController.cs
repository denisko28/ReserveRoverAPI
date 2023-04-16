using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Exceptions;

namespace ReserveRoverAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlacesController : ControllerBase
{
    private readonly IPlacesService _placesService;

    public PlacesController(IPlacesService placesService)
    {
        _placesService = placesService;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PlaceSearchResponse>>> Search([FromQuery] PlaceSearchRequest request)
    {
        try
        {
            var results = await _placesService.Search(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [AllowAnonymous]
    [HttpGet("details/{placeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PlaceDetailsResponse>> GetPlaceDetails(int placeId)
    {
        try
        {
            var results = await _placesService.GetPlaceDetails(placeId);
            return Ok(results);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new {e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    // [Authorize(Roles = "Manager")]
    [HttpGet("manager/{managerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PlaceDetailsResponse>> GetManagersPlace(string managerId)
    {
        try
        {
            var results = await _placesService.GetManagersPlace(managerId);
            return Ok(results);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new {e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    // [Authorize(Roles = "Manager")]
    [HttpPost("createPlace")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> CreatePlace(AddPlaceRequest request)
    {
        try
        {
            var results = await _placesService.CreatePlace(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
}