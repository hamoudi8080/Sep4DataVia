using System.Collections.Generic;
using System.Threading.Tasks;
using Model;


namespace WebAPI.Gateway.Persistence
{
    public interface ILoRaWANRepo
    {
     
        Task<Measurement> AddMeasurement(Measurement measurement);
    }
}