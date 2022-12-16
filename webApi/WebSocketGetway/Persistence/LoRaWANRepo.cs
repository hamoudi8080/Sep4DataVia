using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.Gateway.Persistence
{
    public class LoRaWANRepo : ILoRaWANRepo
    {
        private DataAccess1 dbContext;

        public LoRaWANRepo()
        {
            dbContext = new DataAccess1();
        }

        public async Task<Measurement> AddMeasurement(Measurement measurement)
        {
            EntityEntry<Measurement> addEntity = await dbContext.Measurement.AddAsync(measurement);

            await dbContext.SaveChangesAsync();
            return addEntity.Entity;
        }
    }
}