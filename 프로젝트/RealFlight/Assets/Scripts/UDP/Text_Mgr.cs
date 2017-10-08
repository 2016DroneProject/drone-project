using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Text_Mgr : MonoBehaviour {

	public GameObject udp;


//	public UDPReceive recv;



	public byte[] recbyte;

    public class ReceivePacket
    {
        public float ConnectCheck;
        //	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)] 	
        public string name;
        public float altitude, longitude, Latitude; //고도, 위도 , 경도
        public float pitch, roll, yaw; // 기울기
        public float speed;
        public bool bAttack;

    }

    public ReceivePacket rcvPack = new ReceivePacket();

	public void Command(byte[] ord)
	{
		String json;
		recbyte = ord;		
		//Debug.Log ("json_length : "+ord.Length);
		json = Encoding.UTF8.GetString(ord);
		rcvPack = JsonUtility.FromJson<ReceivePacket>(json);      
	
		//check = true;
		//rcvPack = (ReceivePacket)ByteToStructure(recbyte, typeof(ReceivePacket));
	}

	public static object ByteToStructure(byte[] data, Type type)

	{

		IntPtr buff = Marshal.AllocHGlobal(data.Length); 

		Marshal.Copy(data, 0, buff, data.Length); 

		object obj = Marshal.PtrToStructure(buff, type); 

		Marshal.FreeHGlobal(buff); 


		if (Marshal.SizeOf(obj) != data.Length)

		{
			return null; 			
		}

		return obj; 

	}


	void Awake()
	{
		//order = udp.GetComponent<Order> ();
	}
	// Use this for initialization
	void Start () {


		
	}

	// Update is called once per frame
	void Update () {
       
        //		str4.text = "메시지 : "+order.rcvPack.graphicQuality.ToString();

        Debug.Log(rcvPack.bAttack.ToString());



    }
}
