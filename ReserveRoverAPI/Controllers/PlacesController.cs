using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Enums;
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
    
    [AllowAnonymous]
    [HttpGet("reviews")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PlaceDetailsResponse>> GetPlaceReviews([FromQuery] GetPlaceReviewsRequest request)
    {
        try
        {
            var results = await _placesService.GetPlaceReviews(request);
            return Ok(results);
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

    [Authorize(Roles = UserRoles.Manager)]
    [HttpPost("manager/uploadImage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<string>> UploadImage(IFormFile image)
    {
        try
        {
            var results = await _placesService.UploadImage(image, HttpContext);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [Authorize(Roles = UserRoles.Manager)]
    [HttpPost("manager/setImages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<string>> SetImages(IEnumerable<string> imageUrls)
    {
        try
        {
            await _placesService.SetImages(imageUrls, HttpContext);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [Authorize(Roles = UserRoles.Manager)]
    [HttpPost("manager/createPlace")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> CreatePlace(AddPlaceRequest request)
    {
        try
        {
            var results = await _placesService.CreatePlace(request, HttpContext);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [Authorize(Roles = UserRoles.Manager)]
    [HttpPost("manager/addTableSets")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> AddTableSets(AddPlaceTableSetsRequest request)
    {
        try
        {
            var results = await _placesService.AddPlaceTableSets(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [Authorize(Roles = UserRoles.Manager)]
    [HttpPut("manager/updateTableSets")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> UpdateTableSets(UpdateTableSetsRequest request)
    {
        try
        {
            var results = await _placesService.UpdatePlaceTableSets(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [Authorize]
    [HttpPost("createReview")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> CreatePlaceReview(CreatePlaceReviewRequest request)
    {
        try
        {
            var results = await _placesService.CreateReview(request, HttpContext);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
}