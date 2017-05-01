package com.actimedia.udptest;

/**
 * Created by admin on 2016-10-23.
 */


public class PC_Send_Protocol {
    public float ltLongitude = 0, ltLatitude = 0;
    public float lbLongitude = 0, lbLatitude = 0;
    public float rtLongitude = 0, rtLatitude = 0;
    public float rbLongitude = 0, rbLatitude = 0;
    public float altitude = 0, longitude = 0, Latitude = 0; //고도, 위도 , 경도
    public float pitch =0, roll=0, yaw=0; // 기울기
    public float speed;
    public boolean bAttack_Ready = false;
    public int kind_item  = 0;
    public boolean bWeaponChange = false;
    public boolean bWeaponChangeR = false;
    public double dVariationAngle = 0.0;
    public double dMoveX = 0.0, dMoveY = 0.0;
    public boolean bDisturb = false;
}


