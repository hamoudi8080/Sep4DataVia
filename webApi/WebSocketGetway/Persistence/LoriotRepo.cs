using System;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace WebAPI.Gateway.Persistence
{
    public class LoriotRepo : ILoriotRepo
    {
        
        
        
        
        
        // public async Task AddTemperatureAsync(Temperature temperature)
        // {
        //     try
        //     {
        //         await using var database = new Database();
        //         
        //         await database.Temperatures.AddAsync(temperature);
        //         await database.SaveChangesAsync();
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //     }
        // }
        //
        // public async Task AddHumidityAsync(Humidity humidity)
        // {
        //     await using var database = new Database();
        //
        //     await database.Humidities.AddAsync(humidity);
        //     await database.SaveChangesAsync();
        // }
        //
        // public async Task AddCo2Async(COTwo co2)
        // {
        //     await using var database = new Database();
        //
        //     await database.CoTwos.AddAsync(co2);
        //     await database.SaveChangesAsync();
        // }

        // public async Task AddMeasurement(Measurement measurement, string eui)
        // {
        //     await using var database = new Database();
        //
        //     await database.Measurements.AddAsync(measurement);
        //     var plant = await database.Plants.Include(p => p.Measurements)
        //         .FirstAsync(p => p.EUI.Equals(eui));
        //     plant.Measurements.Add(measurement);
        //     database.Update(plant);
        //     await database.SaveChangesAsync();
        // }

        public Task AddMeasurement(Measurement measurement, string eui)
        {
            throw new NotImplementedException();
        }
    }
}