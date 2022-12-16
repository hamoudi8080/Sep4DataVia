using Model;
using WebAPI.Gateway.Persistence;
using WebAPI.Gateway.Service;
using WebAPI.WebSocketGetway.Model;

namespace WebAPI.WebSocketGetway.Services
{
    public class LoRaWANServiceImp : ILoRaWANService
    {
        
        
        
        private readonly ILoRaWANRepo iLoRaWanRepo;
        private MessageProcessor tMessageProcessor;
       
        
        public LoRaWANServiceImp()
        {
            iLoRaWanRepo = new LoRaWANRepo();
            tMessageProcessor = new MessageProcessor();
        }
        public async Task HandlingMessage(IOTMessage message)
        {
       
 

                         var measurement = tMessageProcessor.CreateMeasurement(message);
                         
                         //MSG EUI IS DEVICE ID 
                         //HERE I SAVE MEASUREMENT OBJECT WITH THE DEVICE ID PROVIDED THIS MEASUREMENT
                         await iLoRaWanRepo.AddMeasurement(measurement);
 
        }

        
    }
}
