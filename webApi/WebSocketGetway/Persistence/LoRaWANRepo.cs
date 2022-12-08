using System;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.EntityFrameworkCore;
using Model;

namespace WebAPI.Gateway.Persistence
{
    public class LoRaWANRepo : ILoRaWANRepo
    {
        public async Task AddMeasurement(Measurements measurement, string eui)
        {
            // await using var database = new Database();
            //
            // await database.Measurements.AddAsync(measurement);
            // var plant = await database.Plants.Include(p => p.Measurements)
            //     .FirstAsync(p => p.EUI.Equals(eui));
            // plant.Measurements.Add(measurement);
            // database.Update(plant);
            // await database.SaveChangesAsync();
        }
    }
}