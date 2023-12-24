using AutoMapper;

using BL;
using BL.Scooters.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Service.Controllers.Entities.Scooters;
using Service.Controllers.Entities.Users;

namespace Service.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ScootersController(IProvider<ScooterModel, ScootersModelFilter> provider, IManager<ScooterModel, CreateScooterModel> manager, IMapper mapper, ILogger logger) : ControllerBase
{
    private readonly IProvider<ScooterModel, ScootersModelFilter> _provider = provider;
    private readonly IManager<ScooterModel, CreateScooterModel> _manager = manager;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger _logger = logger;

    [HttpGet]
    public IActionResult GetAllScooters()
    {
        var scooters = _provider.Get();

        return Ok(new ScootersListResponse()
        {
            Scooters = scooters.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredScooters([FromQuery] ScootersFilter filter)
    {
        var scooters = _provider.Get(_mapper.Map<ScootersModelFilter>(filter));

        return Ok(new ScootersListResponse()
        {
            Scooters = scooters.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetScooterInfo([FromRoute] Guid id)
    {
        try
        {
            var scooter = _provider.GetInfo(id);

            return Ok(scooter);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateScooter([FromBody] CreateUserRequest request)
    {
        try
        {
            var scooter = _manager.Create(_mapper.Map<CreateScooterModel>(request));

            return Ok(scooter);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateScooterInfo([FromRoute] Guid id, UpdateUserRequest request)
    {
        try
        {
            var scooter = _provider.GetInfo(id);

            if (scooter is null)
            {
                return NotFound($"Scooter with ID {id} not found.");
            }

            _mapper.Map(request, scooter);

            var updatedScooter = _manager.Update(id, scooter);

            return Ok(updatedScooter);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteScooter([FromRoute] Guid id)
    {
        try
        {
            var scooter = _provider.GetInfo(id);

            if (scooter is null)
            {
                return NotFound($"Scooter with ID {id} not found.");
            }

            _manager.Delete(id);

            return Ok($"Scooter with ID {id} deleted successfully.");
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }
}
