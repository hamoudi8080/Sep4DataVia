using System.Diagnostics.Metrics;
using Model;
using WebAPI.service.ServiceInterface;

namespace WebAPI.service;

public class MeasurementService : IMeasurementService
{
    
    
    public Task<Measurements> GetMeasurementAsync(string eui)
    {
        throw new NotImplementedException();
    }

    public Task<List<Measurements>> GetMeasurementHistoryAsync(string eui)
    {
        throw new NotImplementedException();
    }
}