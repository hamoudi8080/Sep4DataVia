using Entities;

namespace WebAPI.Persistance.Interface;

public interface IMeasurementRepo
{
    Task<Measurement> GetMeasurementAsync(string eui);
    Task<List<Measurement>> GetMeasurementHistoryAsync(string eui);
}