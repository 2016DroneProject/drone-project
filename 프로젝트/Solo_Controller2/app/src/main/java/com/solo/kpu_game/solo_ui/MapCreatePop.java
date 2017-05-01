package com.solo.kpu_game.solo_ui;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.MotionEvent;
import android.widget.Button;
import android.view.View;

/**
 * Created by KPU_GAME on 2016-11-17.
 */

public class MapCreatePop extends Activity{

    Button leftTopButton;
    Button rightTopButton;
    Button leftBottomButton;
    Button rightBottomButton;
    Button mapCreateTrueButton;
    Button mapDeleteButton;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        MainActivity.kindofitem = 0;

        MainActivity.rightTop_bool = false;
        MainActivity.leftTop_bool = false;
        MainActivity.leftBottom_bool = false;
        MainActivity.rightBottom_bool = false;

        setContentView(R.layout.mapcreate);
        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);

        int width = dm.widthPixels;
        int height = dm.heightPixels;

        getWindow().setLayout((int)(width*.8),(int)(height*.6));

        leftTopButton = (Button)findViewById(R.id.leftTopBtn);
        leftTopButton.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();
                if (action == MotionEvent.ACTION_DOWN) {

                    if(MainActivity.leftTop_bool == true){
                        MainActivity.leftTop_bool = false;
                        MainActivity.kindofitem = 0;
                    }

                    else if(MainActivity.rightTop_bool == false && MainActivity.leftBottom_bool == false  && MainActivity.rightBottom_bool == false){
                        MainActivity.leftTop_bool = true;
                        MainActivity.kindofitem = 1;
                    }

                    MainActivity.vibrator.vibrate(100);

                    leftTopButton.setBackgroundResource(R.drawable.lefttopsel);
                } else if (action == MotionEvent.ACTION_UP) {
                    if(MainActivity.leftTop_bool)
                        leftTopButton.setBackgroundResource(R.drawable.lefttopfin);
                    else
                        leftTopButton.setBackgroundResource(R.drawable.lefttop);
                }
                return false;
            }
        });

        rightTopButton = (Button)findViewById(R.id.rightTopBtn);
        rightTopButton.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();
                if (action == MotionEvent.ACTION_DOWN) {

                    if(MainActivity.rightTop_bool == true) {
                        MainActivity.rightTop_bool = false;
                        MainActivity.kindofitem = 0;

                    }
                   else if(MainActivity.leftTop_bool == false && MainActivity.leftBottom_bool == false  && MainActivity.rightBottom_bool == false ) {
                        MainActivity.rightTop_bool = true;
                        MainActivity.kindofitem = 2;

                    }

                    MainActivity.vibrator.vibrate(100);



                    rightTopButton.setBackgroundResource(R.drawable.righttopsel);
                } else if (action == MotionEvent.ACTION_UP) {
                    if(MainActivity.rightTop_bool)
                        rightTopButton.setBackgroundResource(R.drawable.righttopfin);
                    else
                        rightTopButton.setBackgroundResource(R.drawable.righttop);
                }
                return false;
            }
        });

       leftBottomButton = (Button)findViewById(R.id.leftBottomBtn);
        leftBottomButton.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();
                if (action == MotionEvent.ACTION_DOWN) {
                    if( MainActivity.leftBottom_bool ==true ) {
                        MainActivity.leftBottom_bool =false;
                        MainActivity.kindofitem = 0;
                    }

                    else if(MainActivity.leftTop_bool == false && MainActivity.rightTop_bool == false  && MainActivity.rightBottom_bool == false ){
                        MainActivity.leftBottom_bool = true;
                        MainActivity.kindofitem = 3;
                    }

                    MainActivity.vibrator.vibrate(100);

                    leftBottomButton.setBackgroundResource(R.drawable.leftbottomsel);
                } else if (action == MotionEvent.ACTION_UP) {
                    if(MainActivity.leftBottom_bool)
                        leftBottomButton.setBackgroundResource(R.drawable.leftbottomfin);
                    else
                        leftBottomButton.setBackgroundResource(R.drawable.leftbottom);
                }
                return false;
            }
        });

        rightBottomButton = (Button)findViewById(R.id.rightBottomBtn);
        rightBottomButton.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();
                if (action == MotionEvent.ACTION_DOWN) {

                    if( MainActivity.rightBottom_bool ==true ) {
                        MainActivity.kindofitem = 0;
                        MainActivity.rightBottom_bool =false;
                    }

                    else if(MainActivity.leftTop_bool == false && MainActivity.rightTop_bool == false  && MainActivity.leftBottom_bool == false ){
                        MainActivity.rightBottom_bool = true;
                        MainActivity.kindofitem = 4;
                    }


                    MainActivity.vibrator.vibrate(100);

                    rightBottomButton.setBackgroundResource(R.drawable.rightbottomsel);
                } else if (action == MotionEvent.ACTION_UP) {
                    if(MainActivity.rightBottom_bool)
                        rightBottomButton.setBackgroundResource(R.drawable.rightbottomfin);
                    else
                        rightBottomButton.setBackgroundResource(R.drawable.rightbottom);
                }
                return false;
            }
        });

        //---
        /*mapCreateTrueButton = (Button)findViewById(R.id.createTrueBtn);
        mapCreateTrueButton.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();
                if (action == MotionEvent.ACTION_DOWN) {
                    MainActivity.vibrator.vibrate(100);
                    mapCreateTrueButton.setBackgroundResource(R.drawable.mapcreatesel);

                    if(!MainActivity.leftTop_bool || !MainActivity.leftBottom_bool || !MainActivity.rightTop_bool || !MainActivity.rightBottom_bool)
                        return false;

                    MainActivity.mapCreateComplete = true;
                    MainActivity.CenterPos.setLongitude(MainActivity.getDroneGpsLongi());
                    MainActivity.CenterPos.setLatitude(MainActivity.getDroneGpsLati());
                    //MainActivity.AngleZeroSet();
                    MainActivity.FirstYawInit();
                    MainActivity.bMiniMapPointSet = true;

                } else if (action == MotionEvent.ACTION_UP) {
                    mapCreateTrueButton.setBackgroundResource(R.drawable.mapcreate);
                }
                return false;
            }
        });

        mapDeleteButton = (Button)findViewById(R.id.mapDeleteBtn);
        mapDeleteButton.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();
                if (action == MotionEvent.ACTION_DOWN) {
                    MainActivity.vibrator.vibrate(100);

                    MainActivity.maxLongi = 0;
                    MainActivity.maxLati  = 0;
                    MainActivity.minLati  = 0;
                    MainActivity.minLongi = 0;

                    MainActivity.leftTop_bool = false;
                    MainActivity.leftBottom_bool = false;
                    MainActivity.rightTop_bool = false;
                    MainActivity.rightBottom_bool = false;

                    leftTopButton.setBackgroundResource(R.drawable.lefttop);
                    leftBottomButton.setBackgroundResource(R.drawable.leftbottom);
                    rightTopButton.setBackgroundResource(R.drawable.righttop);
                    rightBottomButton.setBackgroundResource(R.drawable.rightbottom);

                    MainActivity.mapCreateComplete = false;
                    mapDeleteButton.setBackgroundResource(R.drawable.mapdeletesel);
                } else if (action == MotionEvent.ACTION_UP) {
                    mapDeleteButton.setBackgroundResource(R.drawable.mapdelete);
                }
                return false;
            }
        });
        */
    }

    void lati_longi_set(int i){

//        if(i == 1)
//        {
//            MainActivity.dLTlati = 1.000250;
//            MainActivity.dLTlong = 2.000055;
//        }
//        if(i == 2)
//        {
//            MainActivity.dRTlati = 1.000040;
//            MainActivity.dRTlong = 2.000000;
//        }
//        if(i == 3)
//        {
//            MainActivity.dLBlati = 1.000017;
//            MainActivity.dLBlong = 2.000219;
//        }
//        if(i == 4)
//        {
//            MainActivity.dRBlati = 1.000000;
//            MainActivity.dRBlong = 2.000098;
//        }
//
//        MainActivity.bMiniMapPointSet = true;

        double lati  = MainActivity.getDroneGpsLati();
        double longi = MainActivity.getDroneGpsLongi();

        if(i == 1)
        {
            MainActivity.dLTlati = lati;
            MainActivity.dLTlong = longi;
        }
        if(i == 2)
        {
            MainActivity.dRTlati = lati;
            MainActivity.dRTlong = longi;
        }
        if(i == 3)
        {
            MainActivity.dLBlati = lati;
            MainActivity.dLBlong = longi;
        }
        if(i == 4)
        {
            MainActivity.dRBlati = lati;
            MainActivity.dRBlong = longi;
        }

        if(MainActivity.maxLati <= lati || MainActivity.maxLati == 0)
            MainActivity.maxLati = lati;
        if(MainActivity.minLati >= lati || MainActivity.minLati == 0)
            MainActivity.minLati = lati;

        if(MainActivity.maxLongi <= longi || MainActivity.maxLongi == 0)
            MainActivity.maxLongi = longi;
        if(MainActivity.minLongi >= longi || MainActivity.minLongi == 0)
            MainActivity.minLongi = longi;
    }
}
