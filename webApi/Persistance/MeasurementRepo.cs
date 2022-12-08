 
using Model;
using WebAPI.Persistance.Interface;

namespace WebAPI.Persistance;

public class MeasurementRepo : IMeasurementRepo
{
    public Task<Measurements? > GetMeasurementAsync(string eui)
    {
        throw new NotImplementedException();
    }

    public Task<List<Measurements>> GetMeasurementHistoryAsync(string eui)
    {
        throw new NotImplementedException();
    }
}