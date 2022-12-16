using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class ThresholdDao : IThreshold
{
    private readonly DataAccess1 dbContest;
 


    public ThresholdDao(DataAccess1 dbContest)
    {
        this.dbContest = dbContest;
    }



    public async Task<Threshold> GetThresholdByMushroomId(string mushroomId)
    {
        Threshold threshold = await dbContest.Thresholds?.FirstOrDefaultAsync(threshold => threshold.mui.MusId == mushroomId);

        if (threshold == null)
        {
            throw new Exception("Provided Mushroom room has no threshold");
        }

        return threshold;
    }

    public async Task<Threshold> PostThresholdAsync(Threshold threshold)
    {
        EntityEntry<Threshold> data = await dbContest.Thresholds.AddAsync(threshold);
        
        await dbContest.SaveChangesAsync();
        Console.WriteLine("Check Data ");
        return data.Entity;
    }
}