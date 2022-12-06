using Entities;

namespace WebAPI.service.ServiceInterface;

public interface IMeasurementService
{
    Task<Measurement> GetMeasurementAsync(string eui);
    Task<List<Measurement>> GetMeasurementHistoryAsync(string eui);
}