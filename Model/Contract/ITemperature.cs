namespace Model.Contract;

public interface ITemperature
{
    Task<TemperatureThreshold> GetTemperatureAsync(string mui);
   
    Task<List<TemperatureThreshold>> GetListOfTemperature(string mui);
}