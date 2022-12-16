using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;

namespace WebAPI.Controllers;


[ApiController]
[Route("[Controller]")]
public class ThresholdController:ControllerBase
{
    private readonly IThreshold service;
    public ThresholdController(IThreshold service)
    {
        this.service = service;
    }
    
    [HttpGet]
    [Route("{mushroomId}")]
    public async Task<ActionResult<Threshold>> GetAllMeasurementsByMushroomRoomId([FromRoute] string mushroomId)
    {


        try
        {
            Threshold threshold = await service.GetThresholdByMushroomId(mushroomId);
            return Ok(threshold);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Threshold>> CreateTheshold([FromBody] Threshold theshold)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest("BadRequest");
        }
        try
        {

            Threshold added = await service.PostThresholdAsync(theshold);
            return Ok(added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}