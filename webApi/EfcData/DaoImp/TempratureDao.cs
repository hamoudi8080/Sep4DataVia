using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class TempratureDao:ITemperature

{
    private readonly DataAccess1 dbContext;

    public TempratureDao(DataAccess1 dbContext)
    {
        this.dbContext = dbContext;
    }


    public async Task<TemperatureThreshold> GetTemperatureAsync(string mui)
    {
        var mushroom = await dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(mui));

        if (mushroom==null)
        {
            throw new Exception("Data not found");
        }

        var measurement = mushroom.Measurements.LastOrDefault();
        if (measurement==null)
        {
            throw new Exception("Measurement not found");
        }

        TemperatureThreshold temp = new TemperatureThreshold()
        {
            Id = measurement.MeasureId,
            MusId = mui,
            TempratureLevel = measurement.Temperature,
            TimeStamp = measurement.Timestamp,
        };

        return temp;


    }

    public async Task<List<TemperatureThreshold>> GetListOfTemperature(string mui)
    {
        DateTime dateTime = DateTime.Now.AddDays(-45);

        var mushroom = await dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(mui));

        if (mushroom == null)
        {
            throw new Exception("Data not available");
        }

        var measurement = mushroom.Measurements
            .Where(m => DateTime.Compare(m.Timestamp, dateTime) >= 0).ToList();

        if (!measurement.Any())
        {
            throw new Exception("Measurement not found");

        }

        return measurement.Select(m => new TemperatureThreshold()
        {
            TempratureLevel = m.Temperature,
            MusId = mui,
            TimeStamp = m.Timestamp,
            Id = m.MeasureId
        }).ToList();
    }



}
