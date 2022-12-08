 
using Model;

namespace WebAPI.service.ServiceInterface;

public interface IMeasurementService
{
    Task<Measurements> GetMeasurementAsync(string eui);
    Task<List<Measurements>> GetMeasurementHistoryAsync(string eui);
}