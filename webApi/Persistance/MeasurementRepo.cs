using Entities;
using WebAPI.Persistance.Interface;

namespace WebAPI.Persistance;

public class MeasurementRepo : IMeasurementRepo
{
    public Task<Measurement> GetMeasurementAsync(string eui)
    {
        throw new NotImplementedException();
    }

    public Task<List<Measurement>> GetMeasurementHistoryAsync(string eui)
    {
        throw new NotImplementedException();
    }
}