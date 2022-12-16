using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;


namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MeasurementController:ControllerBase
{
    private readonly IMeasurement measurementService;
    
        
    public MeasurementController(IMeasurement measurementService)
    {
        this.measurementService = measurementService;
       
    }
    
    [HttpGet]
    public async Task<ActionResult<Measurement>> GetMeasurement([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var t = await measurementService.GetMeasurementAsync(mui);
            return Ok(t);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("history")]
    public async Task<ActionResult<IList<Measurement>>> GetHistoryOfMeasurements([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var t = await measurementService.GetMeasurementHistoryAsync(mui);
            return Ok(t);
        }
        catch (Exception e)
        {
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }

   private IEnumerable<Measurement> RemoveDuplicateMeasurements(IEnumerable<Measurement> measurements)
    {
        var measurementsToReturn = new List<Measurement>();
        var encounteredTimestamps = new Dictionary<DateTime, DateTime>();

        foreach (var measurement in measurements)
        {
            if (encounteredTimestamps.ContainsKey(measurement.Timestamp))
            {
                continue;
            }

            measurementsToReturn.Add(measurement);
            encounteredTimestamps[measurement.Timestamp] = measurement.Timestamp;
        }

        return measurementsToReturn;
    }
}