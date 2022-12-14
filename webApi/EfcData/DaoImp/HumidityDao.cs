using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class HumidityDao:IHumidity
{
    private readonly DataAccess1 dbContext;

    public HumidityDao(DataAccess1 dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<HumidityThreshold> GetHumidity2Async(string mui)
    {
        var mashroom = await dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(mui));

        if (mashroom==null)
        {
            throw new Exception("Data not found");
        }

        var measurement = mashroom.Measurements.LastOrDefault();

        if (measurement==null)
        {
            throw new Exception("measurement not found");
        }

        HumidityThreshold humidity = new HumidityThreshold()
        {
            MusId = mui,
            HumidityLevel = measurement.Humidity,
            TimeStamp = measurement.Timestamp,
            Id = measurement.MeasureId
        };
        return humidity;
    }

    public async Task<IList<HumidityThreshold>> GetListOfHumidityAsync(string mui)
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

        return measurements.Select(m => new HumidityThreshold()
        {
            HumidityLevel = m.LightLevel, MusId = mui, TimeStamp = m.Timestamp, Id = m.MeasureId
        }).ToList();

    }
}