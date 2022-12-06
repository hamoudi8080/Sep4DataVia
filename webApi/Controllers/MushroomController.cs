﻿using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MushroomController:ControllerBase
{
    private readonly IMushroom _mashroomServices;

    public MushroomController(IMushroom plantService)
    {
        _mashroomServices = plantService;
    }
    
    [HttpPost]
    
    public async Task<ActionResult<MashroomRoom>> PostPlantAsync([FromBody] MashroomRoom plant)
    {
       
        try
        {
            var added = await _mashroomServices.PostMushroomAsync(plant);
            return Created($"/{added.MusId}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}