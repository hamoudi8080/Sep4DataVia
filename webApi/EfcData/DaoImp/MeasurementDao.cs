using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class MeasurementDao : IMeasurement
{
    private readonly DataAccess1 dbContext;
    

    public MeasurementDao(DataAccess1 dbContext)
    {
        this.dbContext = dbContext;
    }



    public Task AddMeasurements(Measurements measurements)
    {
        throw new NotImplementedException();
    }

    public async Task<Measurements> GetMeasurementAsync(string mui)
    {
        var mashroom = await dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(mui));
       
        if (mashroom == null)
        {
            throw new Exception("data NotFound");
        }

        var measurement = mashroom.Measurements.LastOrDefault();

        if (measurement is null)
        {
            throw new Exception("Measurement not found");
        }

        return measurement;

    }

    public async Task<List<Measurements>> GetMeasurementHistoryAsync(string mui)
    {
        var dateTime = DateTime.Now.AddDays(-45);

        var mashroom = await dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(mui));

        if (mashroom == null)
        {
            throw new Exception("data not found");
        }

        var measurement = mashroom.Measurements
            .Where(m => DateTime.Compare(m.Timestamp, dateTime) >= 0).ToList();
       
        if (!measurement.Any())
            throw new Exception("MeasurementNotFound");
        return measurement;
    }
    
    
}



 
