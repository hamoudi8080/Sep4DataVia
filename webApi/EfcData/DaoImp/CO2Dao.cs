using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class CO2Dao:ICo2Threshhold
{
    private readonly DataAccess1 dbContext;


    public CO2Dao(DataAccess1 dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Co2Threshold> GetCO2Async(string mui)
    {
        
        
        MashroomRoom mashroom = await dbContext.MushroomRooms.
            Include(p => p.Measurements)
            .FirstOrDefaultAsync(p => p.MusId.Equals(mui));
        
        Console.WriteLine(" dataAccess");

        if (mashroom == null)
        {
            throw new Exception("Data NotFound");
        }

        var measurement = mashroom.Measurements.LastOrDefault();
        if (measurement == null)
        {
            throw new Exception("MeasurementNotFound");
        }
        var co2 = new Co2Threshold()
        {
            Id = measurement.MeasureId,
            Co2Level = measurement.Co2Level,
                MUSID = mui,
            TimeStamp = measurement.Timestamp
        };
        return co2;
    }
    

    public async Task<IList<Co2Threshold>> GetListOfCo2Async(string mui)
    {
        DateTime dateTime = DateTime.Now.AddDays(-30);
        
        var mushroom = await dbContext.MushroomRooms.Include(p => p.Measurements)
            .FirstOrDefaultAsync(p => p.MusId.Equals(mui));
            
        if (mushroom == null)
        {
            throw new Exception("Data DeviceNotFound");
        }
            
        var measurements = mushroom.Measurements
            .Where(m => DateTime.Compare(m.Timestamp, dateTime) >= 0).ToList();

        if (!measurements.Any())
            throw new Exception("MeasurementNotFound");
        return measurements.Select(m => new Co2Threshold() 
                {Co2Level = m.Co2Level, MUSID = mui, TimeStamp = m.Timestamp, Id = m.MeasureId})
            .ToList();
    }

    public Task<ICollection<Co2Threshold>> GetCoo2Async(string mui)
    {
        throw new NotImplementedException();
    }
}