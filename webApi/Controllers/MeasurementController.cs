using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;
using WebAPI.DataTransferObject;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MeasurementController:ControllerBase
{
    private readonly IMeasurement _measurementService;
    
        
    public MeasurementController(IMeasurement measurementService)
    {
        _measurementService = measurementService;
       
    }
    
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Measurements>>> AddMeasurements(
        [FromBody] PostMeasurement measurements)
    {
        try
        {
            
            var measurementsWithoutDuplicates = RemoveDuplicateMeasurements(measurements.Measurements);
            await _measurementService.AddMeasurements(measurements.Mui, measurementsWithoutDuplicates);
            return Ok();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    private IEnumerable<Measurements> RemoveDuplicateMeasurements(IEnumerable<Measurements> measurements)
    {
        var measurementsToReturn = new List<Measurements>();
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