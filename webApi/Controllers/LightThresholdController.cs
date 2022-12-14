using Microsoft.AspNetCore.Mvc;
using Model.Contract;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class LightThresholdController:ControllerBase
{
    private readonly ILight lightServices;

    public LightThresholdController(ILight lightServices)
    {
        this.lightServices = lightServices;
    }

    [HttpGet]

    public async Task<ActionResult<LightThreshold>> GetLightAsync([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            LightThreshold light = await lightServices.GetLightAsync(mui);
            return (light);

        }
        catch (Exception e)
        {
            return StatusCode(500,e.Message);
        }
    }

    [HttpGet]
    [Route("History")]

    public async Task<ActionResult<IList<LightThreshold>>> GetListOfLight([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
            
        }

        try
        {
            var light = await lightServices.GetListOfLightAsync(mui);
            return Ok(light);

        }
        catch (Exception e)
        {
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
        
        


    }

}