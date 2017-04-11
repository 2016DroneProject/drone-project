
using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour {
	// receiving Thread
	Thread receiveThread; 
	// udpclient object
	UdpClient client; 

	//public Text_Mgr txtmgr;

	private Order ord;
	// public string IP = "127.0.0.1"; default local
	public int port; // define > init
	// infos
	public string lastReceivedUDPPacket="";
	public string allReceivedUDPPackets=""; // clean up this from time to time!

   

	public void Start()						
	{
		ord = GetComponent<Order> ();
		init(); 



	}
	// init

	private void init()
	{
        receiveThread = null;
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
		receiveThread.Start();
	}


	// receive thread 

	private void ReceiveData() 
	{
		client = new UdpClient(port);
		while (true) 			
		{
			try 
			{
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, port);
				byte[] data = client.Receive(ref anyIP);

				string text = Encoding.UTF8.GetString(data);
               
				lastReceivedUDPPacket = text;
				allReceivedUDPPackets = allReceivedUDPPackets + text;

				//txtmgr.Command(data);
                ord.Command(data);
			}
			catch (Exception err) 
			{
                Debug.Log(err.ToString());
			}
		}
	}

	public string getLatestUDPPacket()
	{
		allReceivedUDPPackets="";

		return lastReceivedUDPPacket;		
	}

    void OnDisable()
    {
        if (receiveThread.IsAlive)
        { 
            receiveThread.Abort();
            receiveThread = null;
        }
		client.Close();
        client = null;
    }
}
