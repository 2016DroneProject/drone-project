using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPSend : MonoBehaviour
{
    public int port;  // define in init

    IPEndPoint remoteEndPoint;
    UdpClient client;

    public string check;

    public void Start()
    {
        init();
    }

    public void init()
    {
        remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, port);
        client = new UdpClient();
    }

    private void sendString(string message)
    {
        try
        {

            byte[] data = Encoding.UTF8.GetBytes(message);

            client.Send(data, data.Length, remoteEndPoint);
        }

        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    public void sendStructure(byte[] data) // 실제 보내는 함수임
    {
        try
        {
            check = Encoding.UTF8.GetString(data);

            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    private void sendEndless(string testStr)
    {
        do
        {
            sendString(testStr);
        }

        while (true);
    }

}
