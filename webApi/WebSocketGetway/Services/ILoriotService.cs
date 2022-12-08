using WebAPI.WebSocketGetway.Model;

namespace WebAPI.WebSocketGetway.Services
{
    public interface ILoriotService
    {
        public Task HandlingMessage(IOTMessage message);
    }
}
