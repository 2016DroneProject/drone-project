package com.actimedia.udp_module;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;


import com.actimedia.udptest.PC_Recv_Protocol;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;
import java.net.SocketTimeoutException;
import java.nio.charset.Charset;
import java.util.Arrays;


/**
 * Created by admin on 2016-10-24.
 */

public class Recv_PC_Thread extends Thread {
    private Boolean loop;
    private DatagramPacket dp = null;

    private DatagramSocket ds = null;
    private PC_Recv_Protocol mPc_recv_packet;
    private boolean mReceiveChecker = false;
    private Context myContext;
    private String TAG;
    //자바는 객체를 기본적으로 call by reference로 넘긴다.
    public Recv_PC_Thread(int port, PC_Recv_Protocol pc_recv_packet, Context context, String tag) throws IOException {// 생성자
        super();
        mPc_recv_packet = pc_recv_packet; // 깊은복사? 얕은 복사?
        //port를 소스로 해서 DatagramSocket 객체를 생성한다.
        ds = new DatagramSocket(port);
       // ds.setSoTimeout(10000);
        myContext = context;
        TAG = tag;

    }
    public void JOtoDrone_recv_Pro(JSONObject jo, PC_Recv_Protocol packet)
    {
        packet.bMarkerRender = (boolean)jo.get("bMarkerRender");
        packet.bValue    = (boolean)jo.get("bValue");
        packet.iId      =  (long)jo.get("Id");
    }
    public boolean getReceiveChecker() { return mReceiveChecker; }
    public void setReceiveChecker(Boolean bool) { mReceiveChecker = bool;}

    @Override
    public void run() {
        byte[] temp = new byte[200];
        dp = new DatagramPacket(temp, temp.length);
        loop = true;
        while(loop){
            try {
                ds.receive(dp);
                setReceiveChecker(true);
                int count = 0;
                for(int i=0; i<200; i++)
                {
                    if(temp[i] == 0)
                    {

                        break;
                    }
                    count++;
                }
                byte[] rb = new byte[count];
                for(int i=0; i<count; i++)
                    rb[i] = temp[i];

                //     int a = ds.getReceiveBufferSize();
                //    byte[] rb = new byte[ds.getReceiveBufferSize()];
                String s1   = new String(rb, Charset.forName("UTF-8"));
                Object obj;
                try{
                    JSONParser parser = new JSONParser();
                    obj = parser.parse(s1);

                    JSONObject recv_jo= (JSONObject)obj;
                    JOtoDrone_recv_Pro(recv_jo, mPc_recv_packet);


                }catch (ParseException pe) { }
                Arrays.fill(temp, (byte) 0);
                dp.setLength(temp.length);
            } catch (SocketTimeoutException e) {
            } catch (SocketException e) {
            } catch (Exception e) {
                System.out.printf("S: Error \n", e);
                e.printStackTrace();
            }
        }
        ds.close();
    }

    public void quit() {
        loop = false;
        ds.close();
    }
}
