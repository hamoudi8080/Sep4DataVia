namespace Model.Contract;

public interface IMeasurementSetting
{
    Task<MeasurementSetting> GetHumidityAsync(string mui);
    Task<IList<MeasurementSetting>> GetListOfHumidityAsync(string mui);
    
    
    //Task<COTwo> GetCO2Async();
        
    Task<MeasurementSetting> GetCO2Async(string eui);
    //Task PostCO2Async(COTwo co2);
    //Task DeleteHumidityAsync(object validEui);
    Task<IList<MeasurementSetting>> GetListOfCo2Async(string eui);
    
    //Task<Temperature> GetTemperatureAsync();
    Task<MeasurementSetting> GetTemperatureAsync(string eui);
    //Task PostTemperatureAsync(Temperature temperature);
    //Task DeleteTemperatureAsync(string eui);
    Task<IList<MeasurementSetting>> GetListOfTemperaturesAsync(string eui);
    
    Task<MeasurementSetting> GetLightAsync(string eui);
    Task<IList<MeasurementSetting>> GetListLightAsync(string eui);
    
}