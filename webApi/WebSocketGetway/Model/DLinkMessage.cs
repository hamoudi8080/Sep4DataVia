namespace WebAPI.WebSocketGetway.Model
{
    public class DLinkMessage
    {

        public string cmd { get; set; }
        public string EUI { get; set; }
        public int port { get; set; }
        public bool? confirmed { get; set; }
        public string data { get; set; }

        public override string ToString()
        {
            return
                $"DLink Message => CMD = {cmd}, EUI = {EUI}, PORT = {port}, CONFIRMED = {confirmed}, DATA = {data}";
        }


    }
}
