namespace Model.Contract;

public interface IMeasurement
{
    Task AddMeasurements( Measurement measurements);
   
    
    Task<Measurement> GetMeasurementAsync(string mui);
    
    Task<List<Measurement>> GetMeasurementHistoryAsync(string mui);
}