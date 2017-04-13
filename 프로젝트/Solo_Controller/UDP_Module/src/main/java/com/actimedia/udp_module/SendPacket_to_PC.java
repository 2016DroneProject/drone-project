package com.actimedia.udp_module;

/**
 * Created by admin on 2016-10-26.
 */
import org.json.simple.JSONObject;
import org.json.simple.JSONValue;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.SocketAddress;

import com.actimedia.udptest.*;
import com.actimedia.udp_module.*;
public class SendPacket_to_PC implements Runnable{
    private int port_send;
    private String ip;
    private JSONObject j_obj;
    public PC_Send_Protocol mPC_send_packet;

    public void GetInfo(String ip, int port_send, PC_Send_Protocol pc_send_packet)
    {
        mPC_send_packet = pc_send_packet;
        this.ip = ip;
        this.port_send = port_send;
        j_obj = new JSONObject();
    }
    public void PC_send_toJo(JSONObject jo, PC_Send_Protocol packet)
    {
        jo.put("ltLongitude",packet.ltLongitude);
        jo.put("ltLatitude",packet.ltLatitude);

        jo.put("lbLongitude",packet.lbLongitude);
        jo.put("lbLatitude",packet.lbLatitude);

        jo.put("rtLongitude",packet.rtLongitude);
        jo.put("rtLatitude",packet.rtLatitude);

        jo.put("rbLongitude",packet.rbLongitude);
        jo.put("rbLatitude",packet.rbLatitude);

        jo.put("longitude", packet.longitude);
        jo.put("altitude", packet.altitude);
        jo.put("Latitude", packet.Latitude);
        jo.put("yaw", packet.yaw);
        jo.put("roll", packet.roll);
        jo.put("pitch", packet.pitch);
        jo.put("speed",packet.speed);
        jo.put("bAttack",packet.bAttack_Ready);
        jo.put("bWeaponChange",packet.bWeaponChange);
        jo.put("bWeaponChangeR",packet.bWeaponChangeR);
        jo.put("dVariationAngle",packet.dVariationAngle);
        jo.put("dMoveX",packet.dMoveX);
        jo.put("dMoveY",packet.dMoveY);
        jo.put("bDisturb",packet.bDisturb);
    }

    @Override
    public void run() {
        try {
            SocketAddress socketAddress = new InetSocketAddress("255.255.255.255", port_send);
            DatagramSocket ds = new DatagramSocket();

            PC_send_toJo(j_obj, mPC_send_packet);
            String jsonText = JSONValue.toJSONString(j_obj);
            byte[] sendbuffer = jsonText.getBytes("UTF-8");

            // byte[] sendbuffer = SerializationUtils.serialize(DRONE_Packet);
            DatagramPacket dp = new DatagramPacket(sendbuffer, sendbuffer.length, socketAddress);
            ds.send(dp);
            j_obj.clear();

           // final String s2 = "수신된 데이터 이름: " + mPC_send_packet.name;

            Runnable showUpdate = new Runnable() {
                @Override
                public void run() {
                    //      text.setText(s2);
//						Toast.makeText(getApplicationContext(), s2, Toast.LENGTH_SHORT);
                }
            };

            //         text.post(showUpdate);
            ds.close();
        } catch (IOException ioe) {
            ioe.printStackTrace();
        }
    }
}
