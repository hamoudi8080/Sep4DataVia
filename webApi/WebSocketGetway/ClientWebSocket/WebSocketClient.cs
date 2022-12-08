
using System.Text.Json;
using WebAPI.WebSocketGetway.Model;
using WebAPI.WebSocketGetway.Services;
using WebSocketSharp;


namespace WebAPI.WebSocketGetway.ClientWebSocket
{

    public sealed class WebSocketClient
    {
        private static readonly Lazy<WebSocketClient> lazy = new(() => new WebSocketClient());

        private WebSocket  ws;

        private string Url =
           "wss://iotnet.teracom.dk/app?token=vnoUeQAAABFpb3RuZXQudGVyYWNvbS5kayL9sv9it8LFL5jggp-rve4=";
        private ILoriotService _loriotService;

        public static WebSocketClient Instance => lazy.Value;

        // as we need to handle situation that we don't know exactly when they will happen,
        // so, to receive a msg from the server etc, we use event handlers: onClose, onMessage, onOpen...
        // those are event handlers that we can subscribe to.
        private WebSocketClient()
        {
            _loriotService = new LoriotImp();
            ws = new WebSocket(Url);
            ws.OnOpen += OnOpen;
            ws.OnMessage += OnMessage;
            ws.OnError += _socket_OnError;
            ws.OnClose += OnClose;
            ws.Connect();
        }

        private void _socket_OnError(object? sender, WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine("GATEWAY CONTROLLER => ERROR OCCURED: " + e.Message);
        }

        public void SendDownLinkMessage(string eui, int toOpen)
        {
            string data = toOpen == 1 ? "01" : "00";

            var message = new DLinkMessage()
            {
                cmd = "tx",
                EUI = eui,
                port = 1,
                confirmed = true,
                data = data
            };
            //serialize the message 
            // DLinkMessage m = new DLinkMessage();
            // m.EUI = "hello";
            // m.cmd = "key";
            // m.data = "hello there";
            // m.port = 1;
            // m.confirmed = true;
            
            string serializeMsg  = JsonSerializer.Serialize(message);
            Console.WriteLine(serializeMsg);
            ws.Send(serializeMsg);
        }

        public void GetCacheReadings()
        {
            var message = new Message
            {
                cmdMessage = "cq"
            };
            var json = JsonSerializer.Serialize(message);
            ws.Send(json);
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

            Console.WriteLine($"GATEWAY CONTROLLER => {message}");
          _loriotService.HandlingMessage(message);
        }

        

        private void OnClose(object? sender, CloseEventArgs e)
        {
            Console.WriteLine("HELLO THERE GATEWAY CONTROLLER => Connection closed: " + e.Code);
        }
    }

}
