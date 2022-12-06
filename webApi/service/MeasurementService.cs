using Entities;
using WebAPI.service.ServiceInterface;

namespace WebAPI.service;

public class MeasurementService : IMeasurementService
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