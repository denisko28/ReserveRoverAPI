using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Services.Abstract;

namespace ReserveRoverAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICitiesService _citiesService;

    public CitiesController(ICitiesService citiesService)
    {
        _citiesService = citiesService;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<CityResponse>>> Get()
    {
        try
        {
            var result = await _citiesService.GetAll();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
}