using WebAPI.WebSocketGetway.ClientWebSocket;

namespace WebAPI.service;

public class DummyClass
{
    
    public DummyClass(   )
    {
        
    }

    public void s()
    {

        string euii = "0004A30B00E7E212";
        int open = 1;
        WebSocketClient client = WebSocketClient.Instance;
        client.SendDownLinkMessage(euii, open);
    }
}