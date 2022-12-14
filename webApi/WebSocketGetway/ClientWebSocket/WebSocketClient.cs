using System.Text.Json;
using WebAPI.WebSocketGetway.Model;
using WebAPI.WebSocketGetway.Services;
using WebSocketSharp;


namespace WebAPI.WebSocketGetway.ClientWebSocket
{
    public sealed class WebSocketClient
    {
        private static readonly Lazy<WebSocketClient> lazy = new(() => new WebSocketClient());

        private WebSocket ws;

        private string Url =
            "wss://iotnet.teracom.dk/app?token=vnoUeQAAABFpb3RuZXQudGVyYWNvbS5kayL9sv9it8LFL5jggp-rve4=";


        private string eui = "0004A30B00E7E7C1";

        private ILoRaWANService iloRaWanService;

        public static WebSocketClient Instance => lazy.Value;

        // as we need to handle situation that we don't know exactly when they will happen,
        // so, to receive a msg from the server etc, we use event handlers: onClose, onMessage, onOpen...
        // those are event handlers that we can subscribe to.
        private WebSocketClient()
        {
            iloRaWanService = new LoRaWANServiceImp();
            ws = new WebSocket(Url);
            ws.OnOpen += OnOpen;
            ws.OnMessage += OnMessage;
            ws.OnError += _socket_OnError;
            ws.OnClose += OnClose;
            ws.Connect();
            // Task.Run(() => SendDownLinkMessage());
            
            // Task.Run(() =>  postMethodTemperature());
            Task.Run(() =>  postMethodHumidity());
        }

        private void _socket_OnError(object? sender, WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine("GATEWAY CONTROLLER => ERROR OCCURED: " + e.Message);
        }

        // private string type = "Humidity";
        //
        // private int min = 20;
        // private int max = 50;

        // private string type = "Humidity";
        //
        // private int min = 20;
        // private int max = 50;
        
        
      
        // private async Task postMethodTemperature()
        // {
        //     string type = "Temperature";
        //     int min = 20;
        //     int max = 50;
        //     SendDownLinkMessage(type, min, max);
        //     
        //     Thread.Sleep(20000);
        // }
        //
        private async Task postMethodHumidity()
        {
            string type = "Humidity";
            int min = 20;
            int max = 50;
            SendDownLinkMessage(type, min, max);
            
            Thread.Sleep(30000);
        }

        
        public async Task SendDownLinkMessage(string type, int min, int max)
        {
            if (type.Equals("Co2"))
            {
                string minInhex = min.ToString("X4");
                string maxInhex = max.ToString("X4");
                string s = string.Concat(minInhex, maxInhex);
                var message = new DLinkMessage()
                {
                    cmd = "tx",
                    EUI = eui,
                    port = 10,
                    confirmed = true,
                    data = s
                };
            
            
                string serializeMsg = JsonSerializer.Serialize(message);
                Console.WriteLine(serializeMsg);
            
                for (;;)
                {
                    ws.Send(serializeMsg);
                    Thread.Sleep(30000);
                }
            }

            if (type == "Termperature")
            {
                string minInhex = min.ToString("X4");
                string maxInhex = max.ToString("X4");
                string s = string.Concat(minInhex, maxInhex);
                var message = new DLinkMessage()
                {
                    cmd = "tx",
                    EUI = eui,
                    port = 12,
                    confirmed = true,
                    data = s
                };


                string serializeMsg = JsonSerializer.Serialize(message);
                Console.WriteLine(serializeMsg);

                for (;;)
                {
                    ws.Send(serializeMsg);
                    Thread.Sleep(15000);
                }
            }

            if (type.Equals("Humidity"))
            {
                string minInhex = min.ToString("X4");
                string maxInhex = max.ToString("X4");
                string s = string.Concat(minInhex, maxInhex);
                var message = new DLinkMessage()
                {
                    cmd = "tx",
                    EUI = eui,
                    port = 11,
                    confirmed = true,
                    data = s
                };
            
            
                string serializeMsg = JsonSerializer.Serialize(message);
                Console.WriteLine(serializeMsg);
            
                for (;;)
                {
                    ws.Send(serializeMsg);
                    Thread.Sleep(30000);
                     
                }
            }
            
            // if (type == "Light")
            // {
            //     var message = new DLinkMessage()
            //     {
            //         cmd = "tx",
            //         EUI = eui,
            //         port = 13,
            //         confirmed = true,
            //         data = "123C123D"
            //     };
            //
            //
            //     string serializeMsg = JsonSerializer.Serialize(message);
            //     Console.WriteLine(serializeMsg);
            //
            //     for (;;)
            //     {
            //         ws.Send(serializeMsg);
            //         Thread.Sleep(30000);
            //     }
            // }
        }

       

        private void OnOpen(object? sender, EventArgs e)
        {
            Console.WriteLine($"GATEWAY CONTROLLER => CONNECTION ESTABLISHED...");
        }

        // 2 params that the method receives comes from the onMessage event handler
        // then attach the method to the event
        // so, whenever there is a new message/incoming from the loriot, C# knows that it has to execute this function.
        // sender = who is sending the msg
        // MEA = all the arguments contained in that msg / e=event
        private void OnMessage(object? sender, MessageEventArgs e)
        {
            Console.WriteLine("Received from the server: " + e.Data);
            var message = JsonSerializer.Deserialize<IOTMessage>(e.Data);

            
                // IOTMessage dummymsg = new IOTMessage();
                // dummymsg.cmd = "tx";
                // dummymsg.EUI = "0004A30B00E7E7C1";
                // dummymsg.port = 4;
                // dummymsg.data = "0D0F463200A70019";

                if (message.port != 0)
                {
                    Console.WriteLine($"GATEWAY CONTROLLER => {message}");
                    iloRaWanService.HandlingMessage(message);
                }

                Thread.Sleep(5000);
             
        }


        private void OnClose(object? sender, CloseEventArgs e)
        {
            Console.WriteLine("HELLO THERE GATEWAY CONTROLLER => Connection closed: " + e.Code);
        }
    }
}