using System.Collections.Generic;
using System.Threading.Tasks;
using Model;


namespace WebAPI.Gateway.Persistence
{
    public interface ILoRaWANRepo
    {
        // Task AddTemperatureAsync(Temperature temperature);
        // Task AddHumidityAsync(Humidity humidity);
        // Task AddCo2Async(COTwo co2);
        Task AddMeasurement(Measurements measurement, string eui);
    }
}