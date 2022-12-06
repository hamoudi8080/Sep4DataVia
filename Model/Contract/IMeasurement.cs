namespace Model.Contract;

public interface IMeasurement
{
    Task AddMeasurements(string Mui, IEnumerable<Measurements> measurements);
   
    
    /*Task<Measurements> GetMeasurementAsync(string eui);
    Task<List<Measurements>> GetMeasurementHistoryAsync(string eui)*/
}