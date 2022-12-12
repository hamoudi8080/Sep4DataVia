using Microsoft.AspNetCore.Mvc;
using Model.Contract;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TempratureThresholdController:ControllerBase
{
    private readonly ITemperature tempServices;

    public TempratureThresholdController(ITemperature tempServices)
    {
        this.tempServices = tempServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<TemperatureThreshold>> GetLastTemperatureAsync([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var temp = await tempServices.GetTemperatureAsync(mui);
            return Ok(temp);
        }
        catch (Exception e)
        {
            return StatusCode(500,e.Message);
        }
    }

    [HttpGet]
    [Route("History")]

    public async Task<ActionResult<IList<LightThreshold>>> GetListOfLightAsync([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);

        }

        try
        {
            var temp = await tempServices.GetListOfTemperature(mui);
            return Ok(temp);

        }
        catch (Exception e)
        {
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }
}