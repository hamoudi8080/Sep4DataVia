using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class TestDao:ICo2Threshhold
{
    private readonly DataAccess1 dbContext;

    public TestDao(DataAccess1 dbContext)
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
            Co2Level = measurement.Co2,
            MUSID = mui,
            TimeStamp = measurement.Timestamp
        };
        return co2;
    }

    public Task<IList<Co2Threshold>> GetListOfCo2Async(string mui)
    {
        throw new NotImplementedException();
    }
}