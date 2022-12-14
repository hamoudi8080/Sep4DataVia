using Microsoft.EntityFrameworkCore;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class LightDao:ILight
{
    private readonly DataAccess1 dbContext;

    public LightDao(DataAccess1 dbContext)
    {
        this.dbContext = dbContext;
    }


    public async Task<LightThreshold> GetLightAsync(string mui)
    {
        var mashroom = await dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(mui));

        if (mashroom == null)
        {
            throw new Exception("data not found");
        }

        var measurement = mashroom.Measurements.LastOrDefault();
        
        if (measurement == null)
        {
            throw new Exception("Measurement Not Found");
        }

        var light = new LightThreshold()
        {
            Id = measurement.MeasureId,
            LightLevel = measurement.LightLevel,
            TimeStamp = measurement.Timestamp,
            MusId = mui,

        };

        return light;
    }

    public async Task<IList<LightThreshold>> GetListOfLightAsync(string mui)
    {
        DateTime dateTime = DateTime.Now.AddDays(-30);

        var mashroom = await dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(mui));
        
        var measurements = mashroom.Measurements
            .Where(m => DateTime.Compare(m.Timestamp, dateTime) >= 0).ToList();

        if (!measurements.Any())
        {
            throw new Exception("measurement not available");
        }

        return measurements.Select(m => new LightThreshold()
        {
            LightLevel = m.LightLevel, MusId = mui, TimeStamp = m.Timestamp, Id = m.MeasureId
        }).ToList();



    }
}