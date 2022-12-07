using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;


namespace WebAPI.Gateway.Persistence
{
    public interface ILoRaWANRepo
    {
        // Task AddTemperatureAsync(Temperature temperature);
        // Task AddHumidityAsync(Humidity humidity);
        // Task AddCo2Async(COTwo co2);
        Task AddMeasurement(Measurement measurement, string eui);
    }
}