using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class HumidityThresholdController:ControllerBase
{
    private readonly IHumidity humidityServices;

    public HumidityThresholdController(IHumidity humidityServices)
    {
        this.humidityServices = humidityServices;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<HumidityThreshold>> GetHumidityAsync([FromQuery] string mui)
    {
        
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            
            HumidityThreshold humidity = await humidityServices.GetHumidity2Async(mui);
            Console.WriteLine("inside services ");
            
            return Ok(humidity);
           
        }
        catch (Exception e)
        {
            return StatusCode(500,e.Message);
        }
    }
    
    [HttpGet]
    [Route("history")]
    public async Task<ActionResult<IList<HumidityThreshold>>> GetListOfHumidity([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var humidity = await humidityServices.GetListOfHumidityAsync(mui);
            return Ok(humidity);
        }
        catch (Exception e)
        {
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }

}