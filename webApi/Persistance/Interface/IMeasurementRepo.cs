 
using System.Diagnostics.Metrics;
using Model;

namespace WebAPI.Persistance.Interface;

public interface IMeasurementRepo
{
    Task<Measurements> GetMeasurementAsync(string eui);
    Task<List<Measurements>>GetMeasurementHistoryAsync(string eui);
}