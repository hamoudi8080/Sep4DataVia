namespace Model.Contract;

public interface IMeasurement
{
    Task AddMeasurements( Measurements measurements);
   
    
    Task<Measurements> GetMeasurementAsync(string mui);
    
    Task<List<Measurements>> GetMeasurementHistoryAsync(string mui);
}