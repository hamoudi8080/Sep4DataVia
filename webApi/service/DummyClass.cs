using WebAPI.WebSocketGetway.ClientWebSocket;

namespace WebAPI.service;

public class DummyClass
{
    public DummyClass()
    {
    }

    public void s()
    {
        WebSocketClient client = WebSocketClient.Instance;
        client.SendDownLinkMessage();
    }
}