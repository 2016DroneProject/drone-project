using UnityEngine;
using System;
using System.Text;

public class Order : MonoBehaviour
{

    public GameObject gun;

    GunShootingPearl gp;



    private static Order s_Instance = null;
    void Start()
    {
        DontDestroyOnLoad(this);
        gp = gun.GetComponent<GunShootingPearl>();

        

    }
    public enum SENDID { SID_BACHOM, SID_STUN, SID_SPEED, SID_TIME, SID_SPEEDUP};
    // Use this for initialization

    [Serializable()]
    public class SendPacket
    {
        public long Id;
        public bool bValue;
        public bool bMarkerRender;  
    }

    [Serializable()]
    public class ReceivePacket
    {
        public float ltLongitude , ltLatitude;
        public float lbLongitude , lbLatitude;
        public float rtLongitude , rtLatitude;
        public float rbLongitude , rbLatitude;
        public float altitude, longitude, Latitude; //고도, 위도 , 경도
        public float pitch, roll, yaw; // 기울기
        public float speed;
        public bool bAttack;
        public bool bWeaponChange;
        public bool bWeaponChangeR;
        public double dVariationAngle;
        public double dMoveX;
        public double dMoveY;
        public bool bDisturb;
        public int KindItem;
    }

    public SendPacket sndPack = new SendPacket();
    public ReceivePacket rcvPack = new ReceivePacket();

    public byte[] data;

    public UDPSend udpSend;
    public int connectTimer;
    public bool sendbool;


    public void Command(byte[] ord)
    {
        String json;
        json = Encoding.UTF8.GetString(ord);
        rcvPack = JsonUtility.FromJson<ReceivePacket>(json);

        if(rcvPack.bAttack == true)
        {

            gp.shot = true;
            Debug.Log("발사");
            rcvPack.bAttack = false;
        }

        Debug.Log("아이템: " + rcvPack.KindItem);
    }

    public void SendPack(SENDID id, bool value, bool bMarkerRender)
    {
        sndPack.Id = (int)id;
        sndPack.bValue = value;
        sndPack.bMarkerRender = bMarkerRender;

        string json = JsonUtility.ToJson(sndPack);

        byte[] data = Encoding.UTF8.GetBytes(json);

        udpSend.sendStructure(data);

    }

    void OnApplicationQuit()
    {
        s_Instance = null;
        //게임종료시 삭제. 
    }

}