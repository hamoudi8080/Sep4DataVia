using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class MushroomDao:IMushroom
{
    private readonly DataAccess1 dbContext;

    public MushroomDao(DataAccess1 dbContext)
    {
        this.dbContext = dbContext;
    }


    

    

    public async Task<MashroomRoom> PostPlantAsync(MashroomRoom mashroomRoom)
    {
        EntityEntry<MashroomRoom> data = await dbContext.MushroomRooms.AddAsync(mashroomRoom);
        
        await dbContext.SaveChangesAsync();
        Console.WriteLine("Check Data ");
        return data.Entity;
    }

    public Task<MashroomRoom> GetPlantByDeviceAsync(string mui)
    {
        throw new NotImplementedException();
    }

    public async Task<MashroomRoom> DeletePlantAsync(string mui)
    {
        var mashroom=dbContext.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefault(m => m.MusId.Equals(mui));
        if (mashroom == null)
        {
            throw new Exception("data NotFound");
        }

        dbContext.Measurements.RemoveRange(mashroom.Measurements);
        dbContext.MushroomRooms.Remove(mashroom);
        await dbContext.SaveChangesAsync();
        return mashroom;
    }
}
