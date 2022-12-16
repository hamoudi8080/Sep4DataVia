using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MushroomController:ControllerBase
{
    private readonly IMushroom mashroomServices;

    public MushroomController(IMushroom mashroomServices)
    {
        this.mashroomServices = mashroomServices;
    }


    [HttpPost]
    public async Task<ActionResult<MashroomRoom>> CreateMashroom([FromBody] MashroomRoom mashroomRoom)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest("BadRequest");
        }
        try
        {

            MashroomRoom added = await mashroomServices.PostMushroomAsync(mashroomRoom);
            return Ok(added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    
}