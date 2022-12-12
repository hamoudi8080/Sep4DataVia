using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class MeasurementCo2Test
{
    private readonly DataAccess1 dbContest;

    public MeasurementCo2Test(DataAccess1 dbContest)
    {
        this.dbContest = dbContest;
    }


    public Task<Co2Threshold> GetCo2Async(string Mui)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Co2Threshold>> PostCo2Async(string mui)
    {

        throw new Exception();
    }

    public Task<IList<MeasurementThreshold>> PostCo2Async(int MinMax)
    {
        throw new Exception();
    }
}