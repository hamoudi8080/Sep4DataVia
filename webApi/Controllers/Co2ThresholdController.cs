﻿using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class Co2ThreshholdController:ControllerBase
{
    private readonly ICo2Threshhold co2Services;

    public Co2ThreshholdController(ICo2Threshhold co2Services)
    {
        this.co2Services = co2Services;
    }
    
    [HttpGet]
    public async Task<ActionResult<Co2Threshold>> GetCO2Async([FromQuery] string mui)
    {
        
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            
            Co2Threshold co2 = await co2Services.GetCO2Async(mui);
            Console.WriteLine("inside services ");
            
            return Ok(co2);
           
        }
        catch (Exception e)
        {
            return StatusCode(500,e.Message);
        }
    }
    
    [HttpGet]
    [Route("history")]
    public async Task<ActionResult<IList<Co2Threshold>>> GetListOfTemperatures([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var t = await co2Services.GetListOfCo2Async(mui);
            return Ok(t);
        }
        catch (Exception e)
        {
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }
    
    
}