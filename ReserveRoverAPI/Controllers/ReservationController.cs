using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Exceptions;

namespace ReserveRoverAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }
    
    // [Authorize(Roles = "Manager")]
    [HttpGet("getForTimeline")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<IEnumerable<TimelineReservationResponse>>>> GetForTimeline(
        [FromQuery] GetReservationsForTimelineRequest request)
    {
        try
        {
            var results =
                await _reservationService.GetReservationsForTimeline(request, HttpContext);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    // [Authorize(Roles = "Manager")]
    [HttpGet("getByPlace")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PlaceReservationResponse>>> GetByPlace(
        [FromQuery] GetReservationsByPlaceRequest request)
    {
        try
        {
            var results =
                await _reservationService.GetReservationsByPlace(request, HttpContext);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpGet("getByUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<UserReservationResponse>>> GetByUser(
        [FromQuery] GetReservationsByUserRequest request)
    {
        try
        {
            var results =
                await _reservationService.GetReservationsByUser(request, HttpContext);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [HttpGet("getCountByUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReservationResponse>> GetCountByUser(
        [FromQuery] GetReservationsCountByUserRequest request)
    {
        try
        {
            var results =
                await _reservationService.GetReservationsCountByUser(request, HttpContext);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpGet("timeOffers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PlaceTimeOfferResponse>>> GetTimeOffers(
        [FromQuery] GetTimeOffersRequest request)
    {
        try
        {
            var results = await _reservationService.GetTimeOffers(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> CreateReservation(CreateReservationRequest request)
    {
        try
        {
            var result = await _reservationService.CreateReservation(request, HttpContext);
            return Ok(result);
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
    
    [HttpPatch("updateStatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateStatus(UpdateReservationStatusRequest request)
    {
        try
        {
            await _reservationService.UpdateReservationStatus(request, HttpContext);
            return Ok();
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
}