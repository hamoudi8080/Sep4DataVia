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


    public async Task<MashroomRoom> PostMushroomAsync(MashroomRoom mushroom)
    {
        EntityEntry<MashroomRoom> added = await dbContext.MushroomRooms.AddAsync(mushroom);
        await dbContext.SaveChangesAsync();
        return added.Entity;
        

    }

 
    public async Task<MashroomRoom> DeleteMushroomAsync(string mui)
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
