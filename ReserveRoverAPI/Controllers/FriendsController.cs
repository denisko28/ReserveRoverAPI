using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Exceptions;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Exceptions;

namespace ReserveRoverAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendsController : ControllerBase
{
    private readonly IFriendsService _friendsService;

    public FriendsController(IFriendsService friendsService)
    {
        _friendsService = friendsService;
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<FriendshipResponse>>> Get([FromQuery] SearchForFriendsRequest request)
    {
        try
        {
            var result = await _friendsService.GetFriendships(request, HttpContext);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [Authorize]
    [HttpGet("requests")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<FriendshipResponse>>> GetRequests()
    {
        try
        {
            var result = await _friendsService.GetFriendshipRequests(HttpContext);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
    
    [Authorize]
    [HttpGet("getCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FriendsCountResponse>> GetCount()
    {
        try
        {
            var result = await _friendsService.GetCount(HttpContext);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [Authorize]
    [HttpGet("searchForNew")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PublicUserResponse>>> SearchForNew(
        [FromQuery] SearchForFriendsRequest request)
    {
        try
        {
            var result = await _friendsService.SearchForNew(request, HttpContext);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] string friendId)
    {
        try
        {
            await _friendsService.AddFriend(friendId, HttpContext);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [Authorize]
    [HttpPut("accept/{friendshipId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AcceptFriendship(int friendshipId)
    {
        try
        {
            await _friendsService.AcceptFriendship(friendshipId, HttpContext);
            return Ok();
        }
        catch (ForbiddenAccessException e)
        {
            return StatusCode(StatusCodes.Status403Forbidden, new {e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [Authorize]
    [HttpDelete("{friendshipId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFriendship(int friendshipId)
    {
        try
        {
            await _friendsService.DeleteFriendship(friendshipId, HttpContext);
            return Ok();
        }
        catch (ForbiddenAccessException e)
        {
            return StatusCode(StatusCodes.Status403Forbidden, new {e.Message});
        }
        catch (EntityNotFoundException e)
        {
            return StatusCode(StatusCodes.Status404NotFound, new {e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
}