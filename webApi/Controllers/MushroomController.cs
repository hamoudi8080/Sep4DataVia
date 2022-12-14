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

            MashroomRoom addedTeam = await mashroomServices.PostPlantAsync(mashroomRoom);
            return Ok(addedTeam);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    
}