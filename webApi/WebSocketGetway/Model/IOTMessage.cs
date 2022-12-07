namespace WebAPI.WebSocketGetway.Model
{
    public class IOTMessage
    {

        public string cmd { get; set; }

        public string EUI { get; set; }


        public long ts { get; set; }

        public string data { get; set; }
        public int port { get; set; }
        
        public List<IOTMessage> cache { get; set; }

        public override string ToString()
        {


             
            return $"cmd: {cmd}\nEUI: {EUI}\nport: {port}\nts: {ts}\ndata: {data}";
        }

        public void s()
        {
            string g = cmd;

            Console.WriteLine(cmd);
        }
        
    }
}
