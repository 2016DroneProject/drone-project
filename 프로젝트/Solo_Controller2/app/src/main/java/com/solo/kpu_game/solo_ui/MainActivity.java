package com.solo.kpu_game.solo_ui;

import android.content.Intent;
import android.os.Handler;
import android.os.Vibrator;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import android.content.Context;
import android.graphics.SurfaceTexture;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.MotionEvent;
import android.view.Surface;
import android.view.TextureView;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.actimedia.udp_module.Recv_Drone_Thread;
import com.actimedia.udptest.Drone_Recv_Protocol;
import com.actimedia.udptest.Drone_Send_Protocol;
import com.o3dr.android.client.ControlTower;
import com.o3dr.android.client.Drone;
import com.o3dr.android.client.apis.ControlApi;
import com.o3dr.android.client.apis.VehicleApi;
import com.o3dr.android.client.apis.solo.SoloCameraApi;
import com.o3dr.android.client.interfaces.DroneListener;
import com.o3dr.android.client.interfaces.TowerListener;
import com.o3dr.services.android.lib.coordinate.LatLong;
import com.o3dr.services.android.lib.coordinate.LatLongAlt;
import com.o3dr.services.android.lib.drone.attribute.AttributeEvent;
import com.o3dr.services.android.lib.drone.attribute.AttributeType;
import com.o3dr.services.android.lib.drone.companion.solo.SoloAttributes;
import com.o3dr.services.android.lib.drone.companion.solo.SoloState;
import com.o3dr.services.android.lib.drone.connection.ConnectionParameter;
import com.o3dr.services.android.lib.drone.connection.ConnectionResult;
import com.o3dr.services.android.lib.drone.connection.ConnectionType;
import com.o3dr.services.android.lib.drone.property.Altitude;
import com.o3dr.services.android.lib.drone.property.Attitude;
import com.o3dr.services.android.lib.drone.property.Battery;
import com.o3dr.services.android.lib.drone.property.Gps;
import com.o3dr.services.android.lib.drone.property.Home;
import com.o3dr.services.android.lib.drone.property.Speed;
import com.o3dr.services.android.lib.drone.property.State;
import com.o3dr.services.android.lib.drone.property.Type;
import com.o3dr.services.android.lib.drone.property.VehicleMode;
import com.o3dr.services.android.lib.model.AbstractCommandListener;
import com.o3dr.services.android.lib.model.SimpleCommandListener;

import java.util.List;
import java.util.Timer;
import  com.actimedia.udp_module.*;
import com.actimedia.udptest.*;
import java.io.IOException;

public class MainActivity extends AppCompatActivity implements DroneListener, TowerListener{

    // Drone Value
    public static final String TAG = MainActivity.class.getSimpleName();

    static private Drone drone;
    private int droneType = Type.TYPE_UNKNOWN;
    private ControlTower controlTower;
    private final Handler handler = new Handler();

    private static final int DEFAULT_UDP_PORT = 14550;
    //
    double m_dAltitude;
    float m_fAngle = 0.f;
    int m_iFirst_Altitude = 5;

    //
    // UI Value
    private int xDelta, yDelta;
    private float initStickPosX, initStickPosY;

    private ImageView stickImage;

    private double stickLimit = 300;

    float MoveX, MoveY;
    double mx, my, md;

    float updown, LeftRightRot;

    // 드론 지피에스 저장할라고
    boolean bchecktakeoff = true;
    // double  g_HomeLati, g_HomeLongi;
    LatLong g_LatLong;

    Button Upbtn;
    Button Downbtn;
    Button LeftRotBtn;
    Button RightRotBtn;

    boolean UpDown_Possible;
    boolean LeftRightRot_Possible;

    static Vibrator vibrator;

    static double minLati = 0;
    static double maxLati = 0;
    static double minLongi = 0;
    static double maxLongi = 0;

    static boolean mapCreateComplete = false;

    boolean Drone_Back_Start = false;
    boolean Dorne_Back_Possible = false;
    int Drone_Back_cnt = 0;

    long MovementLimit_Start;
    long MovementLimit_Stop;

    static LatLong CenterPos = new LatLong(0,0);

    //공격 또는 버프 에 관한 bool변수들
    boolean bCenterPosMove = false;
    boolean bDroneSpeedDown = false;
    boolean bDroneStun = false;

    boolean bDroneSpeedUp = false;
    long lDroneSpeedUp_Start;
    long lDroneSpeedUp_Stop;
    int iDrone_SpeedUp_cnt = 0;

    long lDroneSpeedDown_Start;
    long lDroneSpeedDown_Stop;
    int iDrone_SpeedDown_cnt = 0;

    //컨트롤을 막는 변수들(스턴이기도함)
    boolean bDroneControlStop = false;
    long lDroneControlStop_Start;
    long lDroneControlStop_Stop;
    int iDrone_ControlStop_cnt = 0;

    //첫마커렌더됬을때 이동막는것
    boolean bTrapRender = false;
    //
    float fDroneSpeedDecreaseValue = 900.f;

    public interface Trap_Id {
        int BACK_HOME = 0;
        int STUN = 1;
        int SPEED_DOWN = 2;
        int SPEED_UP = 3;
};
    //--------
    private Button startVideoStream;
    private Button stopVideoStream;

    private Timer mSendVirtualStickDataTimer;
    private boolean mVerticalControlFlag = true;
    private String mobile_ip = "192.168.3.18";
    private String pc_ip = "192.168.0.6";
    private int port_send = 5550;
    private int port_recv = 5500;

    PC_Send_Protocol PC_send_packet = new PC_Send_Protocol();
    PC_Recv_Protocol PC_recv_packet = new PC_Recv_Protocol();

    Drone_Recv_Protocol drone_recv_packet = new Drone_Recv_Protocol();
    Recv_PC_Thread mRecvPC_thread;

    SendPacket_to_PC mSendDroneThread;

    //
    Button stopBtn;
    Button disturbBtn;
    Button altitudebtn;
    Button attackBtn;
    Button speedUpBtn;
    Button mapCreate_btn;

    static double firstYaw = 0;
    double yawVariation = 0;

    boolean bRange_Limit_Move = false;
    LatLong destPosition = new LatLong(0,0);

    static boolean leftTop_bool = false;
    static boolean rightTop_bool = false;
    static boolean leftBottom_bool = false;
    static boolean rightBottom_bool = false;

    static int kindofitem = 0;
    static boolean item_select = false;

    boolean bRange_Limit_Move_ControlLimit = false;
    long lRange_Limit_Move_ControlLimit_Start;
    long lRange_Limit_Move_ControlLimit_Stop;
    int iRange_Limit_Move_ControlLimit_Cnt = 0;

    boolean bAltitude_Maintain = false;

    static boolean bMiniMapPointSet = false;
    static double dLTlati = 0;
    static double dLTlong = 0;

    static double dLBlati = 0;
    static double dLBlong = 0;

    static double dRTlati = 0;
    static double dRTlong = 0;

    static double dRBlati = 0;
    static double dRBlong = 0;

    static boolean bGpsGet = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //받는 값 미리 초기화 해둠.
        PC_recv_packet.bValue = false;
        PC_recv_packet.iId = 99;
        PC_recv_packet.bMarkerRender = false;
        //
        //--------
        vibrator = (Vibrator)getSystemService(Context.VIBRATOR_SERVICE);






//        Button CenterPosbtn = (Button)findViewById(R.id.centerpos);
//        CenterPosbtn.setOnClickListener(new Button.OnClickListener(){
//            public void onClick(View v){
//                vibrator.vibrate(100);
//                CenterPos.setLongitude(getDroneGpsLongi());
//                CenterPos.setLatitude(getDroneGpsLati());
//            }
//        });





        mapCreate_btn = (Button)findViewById(R.id.mapCreateBtn);
        mapCreate_btn.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();

                if (action == MotionEvent.ACTION_DOWN) {
                    vibrator.vibrate(100);
                    startActivity(new Intent(MainActivity.this,MapCreatePop.class));
                    mapCreate_btn.setBackgroundResource(R.drawable.itemsel);
                } else if (action == MotionEvent.ACTION_UP) {
                    mapCreate_btn.setBackgroundResource(R.drawable.item);
                }
                return false;
            }
        });


        attackBtn = (Button)findViewById(R.id.attackBtn);
        attackBtn.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();

                if (action == MotionEvent.ACTION_DOWN) {
                    vibrator.vibrate(100);
                    UDPPacketAttackSend();
                    //임시확인용
                    FirstYawInit();
                    attackBtn.setBackgroundResource(R.drawable.shotsel);
                } else if (action == MotionEvent.ACTION_UP) {
                    attackBtn.setBackgroundResource(R.drawable.shot);
                }
                return false;
            }
        });

        speedUpBtn = (Button)findViewById(R.id.WeaponBtn);
        speedUpBtn.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int action = event.getAction();

                if (action == MotionEvent.ACTION_DOWN) {
                    vibrator.vibrate(100);
                    UDPPacketWeaponChangeSend();
                    speedUpBtn.setBackgroundResource(R.drawable.itemusesel);
                } else if (action == MotionEvent.ACTION_UP) {
                    speedUpBtn.setBackgroundResource(R.drawable.itemuse);
                }
                return false;
            }
        });
        //---

        mSendDroneThread = new SendPacket_to_PC();
        mSendDroneThread.GetInfo(pc_ip, port_send, PC_send_packet);
        new Thread(mSendDroneThread).start();

        // Drone
        final Context context = getApplicationContext();
        this.controlTower = new ControlTower(context);
        this.drone = new Drone(context);

        UpDown_Possible         = false;
        LeftRightRot_Possible  = false;

        RightRotBtn = (Button) findViewById(R.id.RightRotBtn);
        RightRotBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {

                int action = event.getAction();
                int id = v.getId();

                if (action == MotionEvent.ACTION_DOWN) {
                    if (id == R.id.RightRotBtn) {
                        vibrator.vibrate(100);
                        RightRotBtn.setBackgroundResource(R.drawable.rightrotsel);
                        LeftRightRot_Possible = true;
                        LeftRightRot = 1; //양수값이 Right
                    }
                } else if (action == MotionEvent.ACTION_UP) {
                    if (id == R.id.RightRotBtn) {
                        RightRotBtn.setBackgroundResource(R.drawable.rightrot);
                        LeftRightRot_Possible = false;
                        LeftRightRot = 0;
                    }
                }
                return false;
            }
        });

        LeftRotBtn = (Button) findViewById(R.id.LeftRotBtn);
        LeftRotBtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {

                int action = event.getAction();
                int id = v.getId();

                if (action == MotionEvent.ACTION_DOWN) {
                    if (id == R.id.LeftRotBtn) {
                        vibrator.vibrate(100);
                        LeftRotBtn.setBackgroundResource(R.drawable.leftrotsel);
                        LeftRightRot_Possible = true;
                        LeftRightRot = -1; //음수값이 left
                    }
                } else if (action == MotionEvent.ACTION_UP) {
                    if (id == R.id.LeftRotBtn) {
                        LeftRotBtn.setBackgroundResource(R.drawable.leftrot);
                        LeftRightRot_Possible = false;
                        LeftRightRot = 0;
                    }
                }
                return false;
            }
        });

        Downbtn = (Button) findViewById(R.id.DownBtn);
        Downbtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {

                int action = event.getAction();
                int id = v.getId();

                if (action == MotionEvent.ACTION_DOWN) {
                    if (id == R.id.DownBtn) {
                        vibrator.vibrate(100);
                        Downbtn.setBackgroundResource(R.drawable.downsel);
                        UpDown_Possible = true;
                        updown = 0.25f;
                    }
                } else if (action == MotionEvent.ACTION_UP) {
                    if (id == R.id.DownBtn) {
                        Downbtn.setBackgroundResource(R.drawable.down);
                        UpDown_Possible = false;
                        updown = 0;
                        stopDrone();
                    }
                }
                return false;
            }
        });

        Upbtn = (Button) findViewById(R.id.UpBtn);
        Upbtn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {

                int action = event.getAction();
                int id = v.getId();

                if (action == MotionEvent.ACTION_DOWN) {
                    if (id == R.id.UpBtn) {
                        vibrator.vibrate(100);
                        Upbtn.setBackgroundResource(R.drawable.upsel);
                        UpDown_Possible = true;
                        updown = -0.25f; //
                    }
                } else if (action == MotionEvent.ACTION_UP) {
                    if (id == R.id.UpBtn) {
                        Upbtn.setBackgroundResource(R.drawable.up);
                        UpDown_Possible = false;
                        updown = 0;
                        stopDrone();
                    }
                }
                return false;
            }
        });
        //-----------

        stickImage = (ImageView) findViewById(R.id.movestick);

        initStickPosX = stickImage.getTranslationX();
        initStickPosY = stickImage.getTranslationY();

        stickImage.setOnTouchListener(new View.OnTouchListener() {

            @Override
            public boolean onTouch(View v, MotionEvent event) {
                final int X = (int) event.getRawX();
                final int Y = (int) event.getRawY();

                switch (event.getAction() & MotionEvent.ACTION_MASK) {
                    case MotionEvent.ACTION_DOWN:
                        xDelta = (int) (X - stickImage.getTranslationX());
                        yDelta = (int) (Y - stickImage.getTranslationY());
                        break;
                    case MotionEvent.ACTION_UP:
                        stickImage.setTranslationX(initStickPosX);
                        stickImage.setTranslationY(initStickPosY);

                        stopDrone();
                        UDPPacketMoveXYzeroSend();

                        break;
                    case MotionEvent.ACTION_POINTER_DOWN:
                        break;
                    case MotionEvent.ACTION_POINTER_UP:
                        break;
                    case MotionEvent.ACTION_MOVE:

                        MoveX = X - xDelta - initStickPosX;
                        MoveY = Y - yDelta - initStickPosY;

                        md = Math.sqrt(Math.pow((double)MoveX, 2) + Math.pow(MoveY, 2));

                        if(md > stickLimit && Dorne_Back_Possible == false && !bDroneControlStop)
                        {
                            mx = MoveX / Math.sqrt(Math.pow((double) MoveX, 2) + Math.pow((double) MoveY, 2)) * stickLimit + initStickPosX;
                            stickImage.setTranslationX((float) (mx));

                            my = MoveY / Math.sqrt(Math.pow((double) MoveX, 2) + Math.pow((double) MoveY, 2)) * stickLimit + initStickPosY;
                            stickImage.setTranslationY((float) (my));
                        }

                        else if(Dorne_Back_Possible == false && !bDroneControlStop)
                        {
                            mx = (float) MoveX + initStickPosX;
                            my = (float) MoveY + initStickPosY;

                            stickImage.setTranslationX((float) MoveX + initStickPosX);
                            stickImage.setTranslationY((float) MoveY + initStickPosY);
                        }

                        if(bDroneControlStop || bRange_Limit_Move_ControlLimit){
                            mx = 0.f;
                            my = 0.f;
                        }

                        //첫렌더되었을때 멈추기위해 추기한것
                        if(bTrapRender){
                            stopDrone();
                            mx = 0.f;
                            my = 0.f;
                            break;
                        }

                        UDPPacketMoveXYSend();

                        if(Dorne_Back_Possible == false && !bDroneControlStop && !bRange_Limit_Move_ControlLimit)
                            MoveDrone();

                        break;
                }

                return true;
            }
        });

        // camera

//        final Button takePic = (Button) findViewById(R.id.CaptureBtn);
//        takePic.setOnTouchListener(new View.OnTouchListener(){
//            @Override
//            public boolean onTouch(View v, MotionEvent event) {
//
//                int action = event.getAction();
//                int id = v.getId();
//
//                if (action == MotionEvent.ACTION_DOWN) {
//                    if (id == R.id.CaptureBtn) {
//                        vibrator.vibrate(100);
//                        takePic.setBackgroundResource(R.drawable.capturesel);
//                        takePhoto();
//
//                    }
//                } else if (action == MotionEvent.ACTION_UP) {
//                    if (id == R.id.CaptureBtn) {
//                        takePic.setBackgroundResource(R.drawable.capture);
//                    }
//                }
//                return false;
//            }
//        });
//
//        //Setup the button to trigger the GoPro camera to start video recording.
//        final Button toggleVideo = (Button) findViewById(R.id.RecBtn);
//        toggleVideo.setOnTouchListener(new View.OnTouchListener(){
//            @Override
//            public boolean onTouch(View v, MotionEvent event) {
//
//                int action = event.getAction();
//                int id = v.getId();
//
//                if (action == MotionEvent.ACTION_DOWN) {
//                    if (id == R.id.RecBtn) {
//                        vibrator.vibrate(100);
//                        toggleVideo.setBackgroundResource(R.drawable.recsel);
//                        toggleVideoRecording();
//
//                    }
//                } else if (action == MotionEvent.ACTION_UP) {
//                    if (id == R.id.RecBtn) {
//                        toggleVideo.setBackgroundResource(R.drawable.rec);
//                    }
//                }
//                return false;
//            }
//        });
//
//        final TextureView videoView = (TextureView) findViewById(R.id.videoView);
//        videoView.setSurfaceTextureListener(new TextureView.SurfaceTextureListener() {
//            @Override
//            public void onSurfaceTextureAvailable(SurfaceTexture surface, int width, int height) {
//                alertUser("Video display is available.");
//                startVideoStream.setEnabled(true);
//            }
//
//            @Override
//            public void onSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height) {
//
//            }
//
//            @Override
//            public boolean onSurfaceTextureDestroyed(SurfaceTexture surface) {
//                startVideoStream.setEnabled(false);
//                return true;
//            }
//
//            @Override
//            public void onSurfaceTextureUpdated(SurfaceTexture surface) {
//
//            }
//        });
//
//        //Setup the button to activate video streaming to the Hello Drone app
//        startVideoStream = (Button) findViewById(R.id.PlayBtn);
//        //startVideoStream.setEnabled(false);
//        startVideoStream.setOnTouchListener(new View.OnTouchListener(){
//            @Override
//            public boolean onTouch(View v, MotionEvent event) {
//
//                int action = event.getAction();
//                int id = v.getId();
//
//                if (action == MotionEvent.ACTION_DOWN) {
//                    if (id == R.id.PlayBtn) {
//                        alertUser("Starting video stream.");
//                        vibrator.vibrate(100);
//                        startVideoStream(new Surface(videoView.getSurfaceTexture()));
//                        startVideoStream.setBackgroundResource(R.drawable.playsel);
//
//                    }
//                } else if (action == MotionEvent.ACTION_UP) {
//                    if (id == R.id.PlayBtn) {
//                        startVideoStream.setBackgroundResource(R.drawable.play);
//                    }
//                }
//                return false;
//            }
//        });
//
//        //Setup the button to stop video streaming to the Hello Drone app
//        stopVideoStream = (Button) findViewById(R.id.StopBtn);
//        //stopVideoStream.setEnabled(false);
//        stopVideoStream.setOnTouchListener(new View.OnTouchListener(){
//            @Override
//            public boolean onTouch(View v, MotionEvent event) {
//
//                int action = event.getAction();
//                int id = v.getId();
//
//                if (action == MotionEvent.ACTION_DOWN) {
//                    if (id == R.id.StopBtn) {
//                        stopVideoStream.setBackgroundResource(R.drawable.stopsel);
//                        alertUser("Stopping video stream.");
//                        vibrator.vibrate(100);
//                        stopVideoStream();
//
//                    }
//                } else if (action == MotionEvent.ACTION_UP) {
//                    if (id == R.id.StopBtn) {
//                        stopVideoStream.setBackgroundResource(R.drawable.stop);
//                    }
//                }
//                return false;
//            }
//        });

        UDPPacketReceive();

    }
    @Override
    public void onStart() {
        super.onStart();
        this.controlTower.connect(this);
        updateVehicleModesForType(this.droneType);

    }

    @Override
    public void onStop() {
        super.onStop();
        if (this.drone.isConnected()) {
            this.drone.disconnect();
            updateConnectedButton(false);
        }

        this.controlTower.unregisterDrone(this.drone);
        this.controlTower.disconnect();
    }
    @Override
    public void onTowerConnected() {
        // alertUser("3DR Services Connected");
        this.controlTower.registerDrone(this.drone, this.handler);
        this.drone.registerDroneListener(this);
    }

    @Override
    public void onTowerDisconnected() {
        // alertUser("3DR Service Interrupted");
    }

    // Drone Listener
    // ==========================================================

    @Override
    public void onDroneEvent(String event, Bundle extras) {

        switch (event) {
            case AttributeEvent.STATE_CONNECTED:
                alertUser("Drone Connected");
                updateConnectedButton(this.drone.isConnected());
                updateArmButton();
                checkSoloState();
                break;

            case AttributeEvent.STATE_DISCONNECTED:
                alertUser("Drone Disconnected");
                updateConnectedButton(this.drone.isConnected());
                updateArmButton();
                break;

            case AttributeEvent.STATE_UPDATED:
            case AttributeEvent.STATE_ARMING:
                updateArmButton();
                break;

            case AttributeEvent.TYPE_UPDATED:
                Type newDroneType = this.drone.getAttribute(AttributeType.TYPE);
                if (newDroneType.getDroneType() != this.droneType) {
                    this.droneType = newDroneType.getDroneType();
                    //updateVehicleModesForType(this.droneType);
                }
                break;

            case AttributeEvent.STATE_VEHICLE_MODE:
                break;

            case AttributeEvent.SPEED_UPDATED:  // 스피드
                updateSpeed();
                break;

            case AttributeEvent.ALTITUDE_UPDATED: // 고도
                updateAltitude();
                break;

            case AttributeEvent.HOME_UPDATED: // 홈거리
                //alertUser("HOME_UPDATED");
                //updateDistanceFromHome();
                break;

            case AttributeEvent.GPS_POSITION: // GPS
            case AttributeEvent.GPS_COUNT:
            case AttributeEvent.GPS_FIX:
                updateGPS();
                updateDistanceFromHome();
                break;

            case AttributeEvent.BATTERY_UPDATED:    // 배터리
                updateBattery();
                break;

            case AttributeEvent.ATTITUDE_UPDATED:
                //공격당하는 함수

                if(PC_recv_packet.bMarkerRender){
                    bTrapRender = true;
                    PC_recv_packet.bMarkerRender = false;
                }

                //드론안날려도 이함수들은 계속 들어간다.
                YawUpdate();
                Trap_Check();
                DroneSpeedUp();
                DroneSpeedDown();
                DroneCenterPosMove();
                DroneStun();
                DroneControl_Stop();




                if(mapCreateComplete == true)
                    //Range_Limit();
                    Movement_Limit();

                if(UpDown_Possible)
                    UpDownDrone();
                if(LeftRightRot_Possible)
                    LeftRightRotDrone();

                break;

            default:
//                Log.i("DRONE_EVENT", event); //Uncomment to see events from the drone
                break;
        }

    }

    private void checkSoloState() {
        final SoloState soloState = drone.getAttribute(SoloAttributes.SOLO_STATE);
        if (soloState == null) {
            alertUser("Unable to retrieve the solo state.");
        } else {
            alertUser("Solo state is up to date.");
        }
    }

    @Override
    public void onDroneConnectionFailed(ConnectionResult result) {
        alertUser("Connection Failed:" + result.getErrorMessage());
    }

    @Override
    public void onDroneServiceInterrupted(String errorMsg) {

    }

    public void onBtnConnectTap(View view) {
        if (this.drone.isConnected()) {
            this.drone.disconnect();
        } else {

            Bundle extraParams = new Bundle();

            extraParams.putInt(ConnectionType.EXTRA_UDP_SERVER_PORT, DEFAULT_UDP_PORT); // Set default baud rate to 14550

            ConnectionParameter connectionParams = new ConnectionParameter(ConnectionType.TYPE_UDP, extraParams, null);
            this.drone.connect(connectionParams);
        }

    }

    public void onArmButtonTap(View view) {
        State vehicleState = this.drone.getAttribute(AttributeType.STATE);

        if (vehicleState.isFlying()) {
            // Land
            VehicleApi.getApi(this.drone).setVehicleMode(VehicleMode.COPTER_LAND, new SimpleCommandListener() {
                @Override
                public void onError(int executionError) {
                    alertUser("Unable to land the vehicle.");
                }

                @Override
                public void onTimeout() {
                    alertUser("Unable to land the vehicle.");
                }
            });
        } else if (vehicleState.isArmed()) {
            // Take off

            ControlApi.getApi(this.drone).takeoff(m_iFirst_Altitude, new AbstractCommandListener() {

                @Override
                public void onSuccess() {
                    alertUser("Taking off...");
                }

                @Override
                public void onError(int i) {
                    alertUser("Unable to take off.");
                }

                @Override
                public void onTimeout() {
                    alertUser("Unable to take off.");
                }
            });

            /*//임시 테이크오프 하고 각도 0도로 돌리는데 바로 적용될까
            ControlApi.getApi(this.drone).enableManualControl(true, new ControlApi.ManualControlStateListener() {
                @Override
                public void onManualControlToggled(boolean isEnabled) {
                }
            });

            ControlApi.getApi(this.drone).turnTo(0.f,1,false,new AbstractCommandListener() {
                @Override
                public void onSuccess() {
                    alertUser("turnto success..");
                }

                @Override
                public void onError(int i) {
                    alertUser("turnto bberror.");
                }

                @Override
                public void onTimeout() {
                    alertUser("turnto timeoutout.");
                }
            });*/


        } else if (!vehicleState.isConnected()) {
            // Connect
            alertUser("Connect to a drone first");
        } else {
            // Connected but not Armed
            VehicleApi.getApi(this.drone).arm(true, false, new SimpleCommandListener() {
                @Override
                public void onError(int executionError) {
                    alertUser("Unable to arm vehicle.");
                }

                @Override
                public void onTimeout() {
                    alertUser("Arming operation timed out.");
                }
            });
        }
    }

    // UI updating
    // =========================================================
    protected void updateConnectedButton(Boolean isConnected) {
        Button connectButton = (Button) findViewById(R.id.ConnectBtn);
        if (isConnected) {
            connectButton.setText("Disconnect");
        } else {
            connectButton.setText("Connect");
        }
    }

    protected void updateArmButton() {
        State vehicleState = this.drone.getAttribute(AttributeType.STATE);
        Button armButton = (Button) findViewById(R.id.ArmBtn);

        if (!this.drone.isConnected()) {
            armButton.setVisibility(View.INVISIBLE);
        } else {
            armButton.setVisibility(View.VISIBLE);
        }

        if (vehicleState.isFlying()) {
            // Land
            armButton.setText("LAND");


            //**************************************************
            if(bchecktakeoff) {
                Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
                if (m_iFirst_Altitude -0.5 < droneAltitude.getAltitude()) {
                    Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
                    g_LatLong = droneGps.getPosition();

                    bchecktakeoff = false;
                    alertUser("first gps setting");

                }
            }

        } else if (vehicleState.isArmed()) {
            // Take off
            armButton.setText("TAKE OFF");

        } else if (vehicleState.isConnected()) {
            // Connected but not Armed
            armButton.setText("ARM");
        }
    }

    protected void updateAltitude() {
        TextView altitudeTextView = (TextView) findViewById(R.id.AltitudeText);
        Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
        altitudeTextView.setText(String.format("%3.1f", droneAltitude.getAltitude()) + "m");
    }

    protected void updateSpeed() {
        TextView speedTextView = (TextView) findViewById(R.id.SpeedText);
        Speed droneSpeed = this.drone.getAttribute(AttributeType.SPEED);
        speedTextView.setText(String.format("%3.1f", droneSpeed.getGroundSpeed()) + "m/s");
    }

    protected  void updateGPS()
    {
        //TextView altitudeTextView = (TextView) findViewById(R.id.AltitudeText);

        // Home droneHome = this.drone.getAttribute(AttributeType.HOME);
        // distanceFromHome = distanceBetweenPoints(droneHome.getCoordinate(), vehicle3DPosition);

        //Altitude droneAltitude = this.drone.getAttribute(AttributeType.HOME);
        //altitudeTextView.setText(droneHome.getCoordinate().toString());
    }

    protected void updateDistanceFromHome() {
//        TextView distanceTextView = (TextView) findViewById(R.id.DistanceText);
//        Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
//        double vehicleAltitude = droneAltitude.getAltitude();
//
//        Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
//        LatLong vehiclePosition = droneGps.getPosition();
//
//
//        double distanceFromHome = 0;
//
//        if (droneGps.isValid()) {
//            LatLongAlt vehicle3DPosition = new LatLongAlt(vehiclePosition.getLatitude(), vehiclePosition.getLongitude(), vehicleAltitude);
//            //Home droneHome = this.drone.getAttribute(AttributeType.HOME);
//            LatLongAlt Home3DPosition = new LatLongAlt(g_LatLong.getLatitude(), g_LatLong.getLongitude(), m_iFirst_Altitude);
//
//            TextView altitudeTextView = (TextView) findViewById(R.id.AltitudeText);
//            altitudeTextView.setText(String.format("%3.1f, %3.1f", g_LatLong.getLatitude(), g_LatLong.getLongitude()));
//            distanceFromHome = distanceBetweenPoints(Home3DPosition, vehicle3DPosition);
//        }
//
//        else {
//            distanceFromHome = 0;
//        }
//
//        distanceTextView.setText(String.format("%f", distanceFromHome) + "m");
    }

    protected void updateBattery() {
        TextView batteryTextView = (TextView) findViewById(R.id.BatteryText);

        Battery droneBattery = this.drone.getAttribute(AttributeType.BATTERY);


        batteryTextView.setText(String.format("%f", droneBattery.getBatteryRemain() )+ "%");
    }


    // Helper methods
    // ==========================================================

    public void alertUser(String message) {
        Toast.makeText(getApplicationContext(), message, Toast.LENGTH_SHORT).show();
        Log.d(TAG, message);
    }

/*    protected double distanceBetweenPoints(LatLongAlt pointA, LatLongAlt pointB) {

        if (pointA == null || pointB == null) {
            return 0;
        }

        double R = 6371;    // km
        double dLat = Math.toRadians(pointB.getLatitude() - pointA.getLatitude());
        double dLon = Math.toRadians(pointB.getLongitude() - pointA.getLongitude());

        double a = Math.sin(dLat/2) * Math.sin(dLat/2) +
                Math.cos(Math.toRadians(pointA.getLatitude())) * Math.cos(Math.toRadians(pointB.getLatitude())) *
                Math.sin(dLon/2) * Math.sin(dLon/2);

        double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 -a ));

        double dist = R * c;

        return dist;

    }*/

    protected double distanceBetweenPoints(LatLongAlt pointA, LatLongAlt pointB) {

        if (pointA == null || pointB == null) {
            return 0;
        }

        double theta, dist;
        theta = pointA.getLongitude() - pointB.getLongitude();
        dist = Math.sin(Math.toRadians(pointA.getLatitude())) * Math.sin(Math.toRadians(pointB.getLatitude()))
                + Math.cos(Math.toRadians(pointA.getLatitude())) * Math.cos(Math.toRadians(pointB.getLatitude()))
                * Math.cos(Math.toRadians(theta));

        dist = Math.acos(dist);
        dist = Math.toDegrees(dist);

        dist = dist * 60 * 1.1515;
        dist = dist * 1.609344; // 단위 mile에서 km로 변환
        dist = dist * 1000.0;   // 단위 km에서 m로 변환


        double dz = pointA.getAltitude() - pointB.getAltitude();

        return Math.sqrt(dist * dist + dz * dz);

    }

   /*protected double distanceBetweenPoints(LatLongAlt pointA, LatLongAlt pointB) {
       if (pointA == null || pointB == null) {
            return 0;
       }

       double dx = pointA.getLatitude() - pointB.getLatitude();
       double dy = pointA.getLongitude() - pointB.getLongitude();
       double dz = pointA.getAltitude() - pointB.getAltitude();

       return Math.sqrt(dx * dx + dy * dy + dz * dz);

    }*/

    //임시 버튼추가
    private void UpDownDrone() {

        ControlApi.getApi(this.drone).enableManualControl(true, new ControlApi.ManualControlStateListener() {
            @Override
            public void onManualControlToggled(boolean isEnabled) {
            }
        });

        ControlApi.getApi(this.drone).manualControl(0.f,0.f,updown,new AbstractCommandListener() {
            @Override
            public void onSuccess() {
                alertUser("Pa.");
            }
            @Override
            public void onError(int executionError) {
                //alertUser("b" + executionError);
            }
            @Override
            public void onTimeout() {
                alertUser("Timeout");
            }
        });

        /*ControlApi.getApi(this.drone).enableManualControl(true, new ControlApi.ManualControlStateListener() {
            @Override
            public void onManualControlToggled(boolean isEnabled) {
            }
        });

        if (updown < 0) {
            m_dAltitude += 0.3;
            ControlApi.getApi(this.drone).climbTo(m_dAltitude);
        } else if (updown > 0)
        {
            m_dAltitude -= 0.3;
            ControlApi.getApi(this.drone).climbTo(m_dAltitude);
        }
        else
            stopDrone();*/
    }

    static void AngleZeroSet(){

        ControlApi.getApi(drone).enableManualControl(true, new ControlApi.ManualControlStateListener() {
            @Override
            public void onManualControlToggled(boolean isEnabled) {
            }
        });

        ControlApi.getApi(drone).turnTo(0.f,1,false,new AbstractCommandListener() {
            @Override
            public void onSuccess() {}

            @Override
            public void onError(int i) {}

            @Override
            public void onTimeout() {}
        });
    }

    private void LeftRightRotDrone() {

        ControlApi.getApi(this.drone).enableManualControl(true, new ControlApi.ManualControlStateListener() {
            @Override
            public void onManualControlToggled(boolean isEnabled) {
            }
        });

        if(LeftRightRot > 0 )
        {
            m_fAngle += 3;

            if(m_fAngle >= 360.f)
                m_fAngle = 360.f;
        }
        else if( LeftRightRot < 0)
        {
            m_fAngle -= 3;

            if(m_fAngle <= 0.f)
                m_fAngle = 0.f;
        }
        else if(LeftRightRot == 0)
            return;

        ControlApi.getApi(this.drone).turnTo(m_fAngle,1,false,new AbstractCommandListener() {
            @Override
            public void onSuccess() {
                alertUser("turnto success..");
            }

            @Override
            public void onError(int i) {
                alertUser("turnto bberror.");
            }

            @Override
            public void onTimeout() {
                alertUser("turnto timeoutout.");
            }
        });
    }

    private void MoveDrone(){

        ControlApi.getApi(this.drone).enableManualControl(true, new ControlApi.ManualControlStateListener() {
            @Override
            public void onManualControlToggled(boolean isEnabled) {
            }
        });

        ControlApi.getApi(this.drone).manualControl((float)-my / fDroneSpeedDecreaseValue,(float)mx / fDroneSpeedDecreaseValue,0.f,new AbstractCommandListener() {
            @Override
            public void onSuccess() {
                alertUser("Pa.");
            }
            @Override
            public void onError(int executionError) {
                //alertUser("b" + executionError);
            }
            @Override
            public void onTimeout() {
                alertUser("Timeout");
            }
        });

    }

    protected void stopDrone(){

        ControlApi.getApi(this.drone).pauseAtCurrentLocation(new AbstractCommandListener() {
            @Override
            public void onSuccess() {
                alertUser("aasuccess...");
            }

            @Override
            public void onError(int i) {
                alertUser("bberror.");
            }

            @Override
            public void onTimeout() {
                alertUser("timeoutout.");
            }
        });

    }

    protected void updateVehicleModesForType(int droneType) {

        List<VehicleMode> vehicleModes = VehicleMode.getVehicleModePerDroneType(droneType);
        ArrayAdapter<VehicleMode> vehicleModeArrayAdapter = new ArrayAdapter<VehicleMode>(this, android.R.layout.simple_spinner_item, vehicleModes);
        vehicleModeArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        //this.modeSelector.setAdapter(vehicleModeArrayAdapter);
    }

    private void takePhoto() {
        SoloCameraApi.getApi(drone).takePhoto(new AbstractCommandListener() {
            @Override
            public void onSuccess() {
                alertUser("Photo taken.");
            }

            @Override
            public void onError(int executionError) {
                alertUser("Error while trying to take the photo: " + executionError);
            }

            @Override
            public void onTimeout() {
                alertUser("Timeout while trying to take the photo.");
            }
        });
    }

    private void toggleVideoRecording() {
        SoloCameraApi.getApi(drone).toggleVideoRecording(new AbstractCommandListener() {
            @Override
            public void onSuccess() {
                alertUser("Video recording toggled.");
            }

            @Override
            public void onError(int executionError) {
                alertUser("Error while trying to toggle video recording: " + executionError);
            }

            @Override
            public void onTimeout() {
                alertUser("Timeout while trying to toggle video recording.");
            }
        });
    }

    private void startVideoStream(Surface videoSurface) {
        SoloCameraApi.getApi(drone).startVideoStream(videoSurface, "", true, new AbstractCommandListener() {
            @Override
            public void onSuccess() {
                if (stopVideoStream != null)
                    stopVideoStream.setEnabled(true);

                if (startVideoStream != null)
                    startVideoStream.setEnabled(false);
            }

            @Override
            public void onError(int executionError) {
                alertUser("Error while starting the video stream: " + executionError);
            }

            @Override
            public void onTimeout() {
                alertUser("Timed out while attempting to start the video stream.");
            }
        });
    }

    private void stopVideoStream() {
        SoloCameraApi.getApi(drone).stopVideoStream(new SimpleCommandListener() {
            @Override
            public void onSuccess() {
                if (stopVideoStream != null)
                    stopVideoStream.setEnabled(false);

                if (startVideoStream != null)
                    startVideoStream.setEnabled(true);
            }
        });
    }
    public void UDPPacketMoveXYzeroSend(){
        Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
        Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
        Attitude droneAttitude = this.drone.getAttribute(AttributeType.ATTITUDE);

        if(bMiniMapPointSet)
        {
            PC_send_packet.ltLatitude = (float)dLTlati;
            PC_send_packet.ltLongitude = (float)dLTlong;

            PC_send_packet.lbLatitude = (float)dLBlati;
            PC_send_packet.lbLongitude = (float)dLBlong;

            PC_send_packet.rtLatitude = (float)dRTlati;
            PC_send_packet.rtLongitude = (float)dRTlong;

            PC_send_packet.rbLatitude = (float)dRBlati;
            PC_send_packet.rbLongitude = (float)dRBlong;
        }

        PC_send_packet.altitude = (float)droneAltitude.getAltitude();
        if(bGpsGet)
        {
            PC_send_packet.longitude = (float) droneGps.getPosition().getLongitude();
            PC_send_packet.Latitude = (float) droneGps.getPosition().getLatitude();
        }
        PC_send_packet.pitch = (float)droneAttitude.getPitch();
        PC_send_packet.roll = (float)droneAttitude.getRoll();
        PC_send_packet.yaw = (float)droneAttitude.getYaw();

        PC_send_packet.speed = 4.5f;
        PC_send_packet.bAttack_Ready = false;
        PC_send_packet.bWeaponChange = false;
        PC_send_packet.bWeaponChangeR = false;
        PC_send_packet.kind_item = 0;
        PC_send_packet.dVariationAngle = yawVariation;

        PC_send_packet.dMoveX = 0.0;
        PC_send_packet.dMoveY = 0.0;

        PC_send_packet.bDisturb = false;

        mSendDroneThread = new SendPacket_to_PC();
        mSendDroneThread.GetInfo(pc_ip, port_send, PC_send_packet);
        new Thread(mSendDroneThread).start();
    }
    public void UDPPacketMoveXYSend(){
        Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
        Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
        Attitude droneAttitude = this.drone.getAttribute(AttributeType.ATTITUDE);

        if(bMiniMapPointSet)
        {
            PC_send_packet.ltLatitude = (float)dLTlati;
            PC_send_packet.ltLongitude = (float)dLTlong;

            PC_send_packet.lbLatitude = (float)dLBlati;
            PC_send_packet.lbLongitude = (float)dLBlong;

            PC_send_packet.rtLatitude = (float)dRTlati;
            PC_send_packet.rtLongitude = (float)dRTlong;

            PC_send_packet.rbLatitude = (float)dRBlati;
            PC_send_packet.rbLongitude = (float)dRBlong;
        }

        PC_send_packet.altitude = (float)droneAltitude.getAltitude();
        if(bGpsGet)
        {
            PC_send_packet.longitude = (float) droneGps.getPosition().getLongitude();
            PC_send_packet.Latitude = (float) droneGps.getPosition().getLatitude();
        }
        PC_send_packet.pitch = (float)droneAttitude.getPitch();
        PC_send_packet.roll = (float)droneAttitude.getRoll();
        PC_send_packet.yaw = (float)droneAttitude.getYaw();

        PC_send_packet.speed = 4.5f;
        PC_send_packet.bAttack_Ready = false;
        PC_send_packet.bWeaponChange = false;
        PC_send_packet.bWeaponChangeR = false;
        PC_send_packet.kind_item = 0;
        PC_send_packet.dVariationAngle = yawVariation;

        PC_send_packet.dMoveX = mx;
        PC_send_packet.dMoveY = my;


        PC_send_packet.bDisturb = false;

        mSendDroneThread = new SendPacket_to_PC();
        mSendDroneThread.GetInfo(pc_ip, port_send, PC_send_packet);
        new Thread(mSendDroneThread).start();
    }
    public void UDPPacketWeaponChangeSend() {
        Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
        Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
        Attitude droneAttitude = this.drone.getAttribute(AttributeType.ATTITUDE);

        if(bMiniMapPointSet)
        {
            PC_send_packet.ltLatitude = (float)dLTlati;
            PC_send_packet.ltLongitude = (float)dLTlong;

            PC_send_packet.lbLatitude = (float)dLBlati;
            PC_send_packet.lbLongitude = (float)dLBlong;

            PC_send_packet.rtLatitude = (float)dRTlati;
            PC_send_packet.rtLongitude = (float)dRTlong;

            PC_send_packet.rbLatitude = (float)dRBlati;
            PC_send_packet.rbLongitude = (float)dRBlong;
        }

        PC_send_packet.altitude = (float)droneAltitude.getAltitude();
        if(bGpsGet)
        {
            PC_send_packet.longitude = (float) droneGps.getPosition().getLongitude();
            PC_send_packet.Latitude = (float) droneGps.getPosition().getLatitude();
        }
        PC_send_packet.pitch = (float)droneAttitude.getPitch();
        PC_send_packet.roll = (float)droneAttitude.getRoll();
        PC_send_packet.yaw = (float)droneAttitude.getYaw();

        PC_send_packet.speed = 4.5f;
        PC_send_packet.bAttack_Ready = false;
        PC_send_packet.bWeaponChange = true;
        PC_send_packet.bWeaponChangeR = true;
        PC_send_packet.kind_item = kindofitem;
        kindofitem = 0;


        PC_send_packet.dVariationAngle = yawVariation;

        PC_send_packet.dMoveX = 0;
        PC_send_packet.dMoveY = 0;

        PC_send_packet.bDisturb = false;

        mSendDroneThread = new SendPacket_to_PC();
        mSendDroneThread.GetInfo(pc_ip, port_send, PC_send_packet);
        new Thread(mSendDroneThread).start();
    }

    public void UDPPacketAttackSend() {
        Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
        Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
        Attitude droneAttitude = this.drone.getAttribute(AttributeType.ATTITUDE);

        if(bMiniMapPointSet)
        {
            PC_send_packet.ltLatitude = (float)dLTlati;
            PC_send_packet.ltLongitude = (float)dLTlong;

            PC_send_packet.lbLatitude = (float)dLBlati;
            PC_send_packet.lbLongitude = (float)dLBlong;

            PC_send_packet.rtLatitude = (float)dRTlati;
            PC_send_packet.rtLongitude = (float)dRTlong;

            PC_send_packet.rbLatitude = (float)dRBlati;
            PC_send_packet.rbLongitude = (float)dRBlong;
        }

        PC_send_packet.altitude = (float)droneAltitude.getAltitude();
        if(bGpsGet)
        {
            PC_send_packet.longitude = (float) droneGps.getPosition().getLongitude();
            PC_send_packet.Latitude = (float) droneGps.getPosition().getLatitude();
        }
        PC_send_packet.pitch = (float)droneAttitude.getPitch();
        PC_send_packet.roll = (float)droneAttitude.getRoll();
        PC_send_packet.yaw = (float)droneAttitude.getYaw();

        PC_send_packet.speed = 3.5f;
        PC_send_packet.bAttack_Ready = true;
        PC_send_packet.bWeaponChange = false;
        PC_send_packet.bWeaponChangeR = false;
        PC_send_packet.kind_item = 0;
        PC_send_packet.dVariationAngle = yawVariation;

        PC_send_packet.dMoveX = 0;
        PC_send_packet.dMoveY = 0;

        PC_send_packet.bDisturb = false;

        mSendDroneThread = new SendPacket_to_PC();
        mSendDroneThread.GetInfo(pc_ip, port_send, PC_send_packet);
        new Thread(mSendDroneThread).start();
    }

    public void UDPPacketYawVariationSend(){
        Altitude droneAltitude = this.drone.getAttribute(AttributeType.ALTITUDE);
        Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
        Attitude droneAttitude = this.drone.getAttribute(AttributeType.ATTITUDE);

        if(bMiniMapPointSet)
        {
            PC_send_packet.ltLatitude = (float)dLTlati;
            PC_send_packet.ltLongitude = (float)dLTlong;

            PC_send_packet.lbLatitude = (float)dLBlati;
            PC_send_packet.lbLongitude = (float)dLBlong;

            PC_send_packet.rtLatitude = (float)dRTlati;
            PC_send_packet.rtLongitude = (float)dRTlong;

            PC_send_packet.rbLatitude = (float)dRBlati;
            PC_send_packet.rbLongitude = (float)dRBlong;
        }

        PC_send_packet.altitude = (float)droneAltitude.getAltitude();
        if(bGpsGet)
        {
            PC_send_packet.longitude = (float) droneGps.getPosition().getLongitude();
            PC_send_packet.Latitude = (float) droneGps.getPosition().getLatitude();
        }
        PC_send_packet.pitch = (float)droneAttitude.getPitch();
        PC_send_packet.roll = (float)droneAttitude.getRoll();
        PC_send_packet.yaw = (float)droneAttitude.getYaw();

        PC_send_packet.speed = 3.5f;
        PC_send_packet.bAttack_Ready = false;
        PC_send_packet.bWeaponChange = false;
        PC_send_packet.bWeaponChangeR = false;
        PC_send_packet.kind_item = 0;
        PC_send_packet.dVariationAngle = yawVariation;

        PC_send_packet.dMoveX = 0;
        PC_send_packet.dMoveY = 0;

        PC_send_packet.bDisturb = false;

        mSendDroneThread = new SendPacket_to_PC();
        mSendDroneThread.GetInfo(pc_ip, port_send, PC_send_packet);
        new Thread(mSendDroneThread).start();
    }



    public void UDPPacketReceive()
    {
        try {
            mRecvPC_thread = new Recv_PC_Thread(port_recv, PC_recv_packet, getApplicationContext(), TAG);
            new Thread(mRecvPC_thread).start();
        }
        catch(IOException e) {
        }
    }

    private void Movement_Limit() {

        Gps droneGps = this.drone.getAttribute(AttributeType.GPS);
        LatLong vehiclePosition = droneGps.getPosition();

        // if절에 들어갈때는 범위를 넘은것이라 밀어내야한다.
        // 항상 자기자신의 이동 방향을 들고있어야할것이다.

        // 넉백이라는 함수를 만들어서 범위를 넘을시에 일정시간동안 뒤로밀리고
        // 밀리는 동안은 방향키 조작이 안되고 밀리면될것이다.

        // 이동을 제한하기위해서는 불변수를 하나만들어서 드론의 이동을 막아줘야한다.

        if( minLati > vehiclePosition.getLatitude() || maxLati < vehiclePosition.getLatitude() ||
                minLongi > vehiclePosition.getLongitude()  || maxLongi < vehiclePosition.getLongitude() ) {
            Drone_Back_Start = true;
            Dorne_Back_Possible = true;
        }
        else
        {
            Drone_Back_Start = false;
        }

        Drone_Back();
    }

    private void Drone_Back(){

        //드론 백 가능함수가 false 이면 리턴하자.
        if(!Dorne_Back_Possible)
            return;

        //------첫 셋팅 하는 부분이다.-----------
        if(Drone_Back_Start && (Drone_Back_cnt == 0)){

            //뒤로가는 것이 시작된 시간을 저장한것
            MovementLimit_Start = System.currentTimeMillis();
            Drone_Back_Start = false;
        }
        //--------------------------------------

        ++Drone_Back_cnt;
        MovementLimit_Stop = System.currentTimeMillis();

        //--------실제 이동하는 코드-------
        ControlApi.getApi(this.drone).enableManualControl(true, new ControlApi.ManualControlStateListener() {
            @Override
            public void onManualControlToggled(boolean isEnabled) {
            }
        });

        ControlApi.getApi(this.drone).manualControl((float)my / 600.0f,(float)-mx / 600.0f,0.f,new AbstractCommandListener() {
            @Override
            public void onSuccess() {}

            @Override
            public void onError(int executionError) {}
            @Override
            public void onTimeout() {}
        });
        //---------------------------------

        //이 조건은 드론이 뒤로가는 것이 끝났다는 조건이다 다시 백카운트를 0으로 해줄필요가있다.
        if( (MovementLimit_Stop - MovementLimit_Start)/1000 >= 2 )
        {
            Drone_Back_cnt = 0;
            //더이상 백함수에 들어오지않기위해
            Dorne_Back_Possible = false;
            stopDrone();
        }
    }

    static double getDroneGpsLati() {
        Gps droneGps = drone.getAttribute(AttributeType.GPS);
        LatLong vehiclePosition = droneGps.getPosition();

        return vehiclePosition.getLatitude();
    }

    static double getDroneGpsLongi() {
        Gps droneGps = drone.getAttribute(AttributeType.GPS);
        LatLong vehiclePosition = droneGps.getPosition();

        return vehiclePosition.getLongitude();
    }

    void DroneCenterPosMove() {

        if(!bCenterPosMove)
            return;

        alertUser("backhome hamsu");

        bCenterPosMove = false;
        bDroneControlStop = true;

        ControlApi.getApi(this.drone).goTo(CenterPos,true, new AbstractCommandListener(){
            @Override
            public void onSuccess() {
                alertUser("goto");
            }

            @Override
            public void onError(int i) {
                alertUser("gotoerror.");
            }

            @Override
            public void onTimeout() {
                alertUser("gotoout.");
            }
        });
    }

    private void DroneControl_Stop() {

        if (!bDroneControlStop)
            return;

        //------첫 셋팅 하는 부분이다.-----------
        if (iDrone_ControlStop_cnt == 0) {
            lDroneControlStop_Start = System.currentTimeMillis();
        }
        //--------------------------------------

        ++iDrone_ControlStop_cnt;
        lDroneControlStop_Stop = System.currentTimeMillis();


        if ((lDroneControlStop_Stop - lDroneControlStop_Start) / 1000 >= 5) {
            iDrone_ControlStop_cnt = 0;
            bDroneControlStop = false;
        }
    }

    private void DroneSpeedDown(){
        if(!bDroneSpeedDown)
            return;

        if(iDrone_SpeedDown_cnt == 0)
            lDroneSpeedDown_Start = System.currentTimeMillis();

        fDroneSpeedDecreaseValue = 800.f;
        ++iDrone_SpeedDown_cnt;
        lDroneSpeedDown_Stop = System.currentTimeMillis();

        if ((lDroneSpeedDown_Stop - lDroneSpeedDown_Start) / 1000 >= 5) {
            iDrone_SpeedDown_cnt = 0;
            bDroneSpeedDown = false;
            fDroneSpeedDecreaseValue = 400.f;
        }
    }

    private void DroneSpeedUp(){
        if(!bDroneSpeedUp)
            return;

        if(iDrone_SpeedUp_cnt == 0)
            lDroneSpeedUp_Start = System.currentTimeMillis();

        fDroneSpeedDecreaseValue = 200.f;
        ++iDrone_SpeedUp_cnt;
        lDroneSpeedUp_Stop = System.currentTimeMillis();

        if ((lDroneSpeedUp_Stop - lDroneSpeedUp_Start) / 1000 >= 5) {
            iDrone_SpeedUp_cnt = 0;
            bDroneSpeedUp = false;
            fDroneSpeedDecreaseValue = 400.f;
        }

    }

    private void DroneStun(){
        if(!bDroneStun)
            return;

        bDroneStun = false;
        bDroneControlStop = true;
        stopDrone();
    }

    private  void Trap_Check(){
        if(PC_recv_packet.iId == Trap_Id.BACK_HOME && PC_recv_packet.bValue){
            bCenterPosMove = true;
            PC_recv_packet.iId = 99;
            PC_recv_packet.bValue = false;
            bTrapRender = false;
            alertUser("Back Home");
            vibrator.vibrate(5000);
        }
        if(PC_recv_packet.iId == Trap_Id.STUN && PC_recv_packet.bValue){
            bDroneStun = true;
            PC_recv_packet.iId = 99;
            PC_recv_packet.bValue = false;
            bTrapRender = false;
            alertUser("Stun");
            vibrator.vibrate(5000);
        }
        if(PC_recv_packet.iId == Trap_Id.SPEED_DOWN && PC_recv_packet.bValue){
            bDroneSpeedDown = true;
            PC_recv_packet.iId = 99;
            PC_recv_packet.bValue = false;
            bTrapRender = false;
            alertUser("Speed Down");
            vibrator.vibrate(5000);
        }

        if(PC_recv_packet.iId == Trap_Id.SPEED_UP)
        {
            PC_recv_packet.iId = 99;
            bDroneSpeedUp = true;
        }
    }

    private void YawUpdate(){
        Attitude droneAtti = this.drone.getAttribute(AttributeType.ATTITUDE);

        double variationTemp =  yawVariation;
        double currentYaw = droneAtti.getYaw();

        if(currentYaw < 0)
            yawVariation = (360.0 + currentYaw) - firstYaw;
        else if(currentYaw >= 0)
            yawVariation = currentYaw - firstYaw;

        if(yawVariation < 0)
            yawVariation = 360.0 + yawVariation;

        if((int)variationTemp != (int)yawVariation ) {
            UDPPacketYawVariationSend();
        }
    }

    static void FirstYawInit(){
        Attitude droneAtti = drone.getAttribute(AttributeType.ATTITUDE);
        firstYaw = droneAtti.getYaw();

        if(firstYaw < 0)
            firstYaw = 360.0 + firstYaw;
    }

    private  void Range_Limit(){

        //---시간재는 것.
        if(bRange_Limit_Move_ControlLimit && (iRange_Limit_Move_ControlLimit_Cnt == 0)){
            lRange_Limit_Move_ControlLimit_Start = System.currentTimeMillis();
        }

        if(bRange_Limit_Move_ControlLimit){
            ++iRange_Limit_Move_ControlLimit_Cnt;
            lRange_Limit_Move_ControlLimit_Stop = System.currentTimeMillis();

            if( (lRange_Limit_Move_ControlLimit_Stop - lRange_Limit_Move_ControlLimit_Start)/1000 >= 3 ){
                bRange_Limit_Move_ControlLimit = false;
                iRange_Limit_Move_ControlLimit_Cnt = 0;
            }
        }
        //

        Gps droneGps = drone.getAttribute(AttributeType.GPS);
        LatLong vehiclePosition = droneGps.getPosition();

        destPosition.setLatitude(vehiclePosition.getLatitude());
        destPosition.setLongitude(vehiclePosition.getLongitude());

        if(vehiclePosition.getLatitude() < minLati){
            alertUser("Range_Limit_Move minLati");
            bRange_Limit_Move = true;
            destPosition.setLatitude(minLati + 0.000080);
        }

        if(vehiclePosition.getLatitude() > maxLati){
            alertUser("Range_Limit_Move maxLati");
            bRange_Limit_Move = true;
            destPosition.setLatitude(maxLati - 0.000080);
        }

        if(vehiclePosition.getLongitude() < minLongi){
            alertUser("Range_Limit_Move minLongi");
            bRange_Limit_Move = true;
            destPosition.setLongitude(minLongi + 0.000080);
        }

        if(vehiclePosition.getLongitude() > maxLongi){
            alertUser("Range_Limit_Move maxLongi");
            bRange_Limit_Move = true;
            destPosition.setLongitude(maxLongi - 0.000080);
        }

        if(bRange_Limit_Move == true){
            iRange_Limit_Move_ControlLimit_Cnt = 0;
            bRange_Limit_Move_ControlLimit = true;
            alertUser("Range_Limit_Move");
            ControlApi.getApi(this.drone).goTo(destPosition,true, new AbstractCommandListener(){
                @Override
                public void onSuccess() {
                    alertUser("goto");
                }

                @Override
                public void onError(int i) {
                    alertUser("gotoerror.");
                }

                @Override
                public void onTimeout() {
                    alertUser("gotoout.");
                }
            });

            bRange_Limit_Move = false;
        }

    }



}

