using WebAPI.Gateway.Persistence;
using WebAPI.Gateway.Service;
using WebAPI.WebSocketGetway.Model;

namespace WebAPI.WebSocketGetway.Services
{
    public class LoriotImp : ILoriotService
    {
        
        
        
        private readonly ILoriotRepo _loriotRepo;
        private MessageProcessor _processor;
       
        
        public LoriotImp()
        {
            _loriotRepo = new LoriotRepo();
            _processor = new MessageProcessor();
        }
        public async Task HandlingMessage(IOTMessage message)
        {
            Console.WriteLine("my message is here now " + message);

            

            switch (message.cmd)
            {
                case "rx":
                    {
                        // var temp = _processor.CreateTemperature(message);
                        // var humidity = _processor.CreateHumidity(message);
                        // var co2 = _processor.CreateCo2(message);
                        //
                        // await _loriotRepo.AddTemperatureAsync(temp);
                        // await _loriotRepo.AddHumidityAsync(humidity);
                        // await _loriotRepo.AddCo2Async(co2);


                         var measurement = _processor.CreateMeasurement(message);
                         await _loriotRepo.AddMeasurement(measurement, message.EUI);
                        break;
                    }
            }
        }
    }
}
