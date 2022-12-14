using Model;
using WebAPI.WebSocketGetway.Model;

namespace WebAPI.WebSocketGetway.Services
{
    public interface ILoRaWANService
    {
        public Task HandlingMessage(IOTMessage message);
       
    }
}
