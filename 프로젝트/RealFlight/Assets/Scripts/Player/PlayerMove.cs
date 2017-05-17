using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

   // public Text_Mgr tm;
   // public CubeMotionMoveSample motion;
   // public bool isUnderWater = false;
    public Vector3 sum;
   // public float DroneSpeed;
   // public float GPSpos_Y; // 고도(y)

   // public float percent = 0.03f;
  //  public float yPercet = 1.05f;
  //  public float Drone_vX, Drone_vY, Drone_vZ;
  //  public Quaternion Yaw = Quaternion.identity;

    float speed = 5.0f;
  //  float Game_vX, Game_vY, Game_vZ;
  //  float pitch, roll, yaw;

   // Vector3 VX, VY, VZ;
  //  AudioSource audio;
   // Collider col;

    void Awake()
    {
       // audio = GetComponent<AudioSource>();
    }

    void Start()
    {
       // col = this.GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider other)
    {
        //if (col.tag == "Player" && other.tag == "Water")
        //{
        //    motion.underWaterStart = true;
        //    motion.Startsecond = 0;
        //    isUnderWater = true;
        //    speed = 3.0f;
        //    audio.Play();
        //}
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Water")
        //{
        //    isUnderWater = false;
        //    speed = 5.0f;
        //}
    }
    void Update()
    {
        //VX = new Vector3(Drone_vX, 0, 0);
        //VZ = new Vector3(0, 0, Drone_vZ);

        //sum = VX + VY + VZ;
        //DroneSpeed = Mathf.Sqrt(sum.x * sum.x + sum.y * sum.y + sum.z * sum.z);

        //Drone_vX = tm.rcvPack.vX * percent;
        //Game_vX += Time.fixedDeltaTime * Drone_vX;

        //GPSpos_Y = tm.rcvPack.altitude;

        //Drone_vZ = tm.rcvPack.vZ * percent;
        //Game_vZ += Time.fixedDeltaTime * Drone_vZ;
    }

    void FixedUpdate()
    {

        ////Yaw.eulerAngles = new Vector3(90.0f, tm.rcvPack.yaw, transform.rotation.z);
        ////transform.rotation = Quaternion.Slerp(transform.rotation, Yaw, Time.deltaTime);

        ////{
        ////    transform.Translate(new Vector3(Game_vX, 0, 0), Space.World);
        ////    transform.Translate(new Vector3(0, 0, Game_vZ), Space.World);

        ////    if (Drone_vX == 0)
        ////    {
        ////        Game_vX = 0;
        ////    }

        ////    else if (Drone_vX != 0)
        ////    {
        ////        Game_vX += Time.fixedDeltaTime * Drone_vX;
        ////    }


        ////    if (GPSpos_Y > 0.01)
        ////    {
        ////        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, GPSpos_Y, 0), Time.fixedDeltaTime * yPercet);
        ////    }

        ////    if (Drone_vZ == 0)
        ////    {
        ////        Game_vZ = 0;
        ////    }
        ////    else if (Drone_vZ != 0)
        ////    {
        ////        Game_vZ += Time.fixedDeltaTime * Drone_vZ;
        ////    }

        //}



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.smoothDeltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.smoothDeltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.smoothDeltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.smoothDeltaTime, 0);
        }

        if (Input.GetKey("a"))
        {
            transform.Rotate(0, speed * Time.smoothDeltaTime * 2f, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, -speed * Time.smoothDeltaTime * 2f, 0, 0);
        }

        if (Input.GetKey("q"))
        {
            transform.Translate(0, 0, speed * Time.smoothDeltaTime);
        }
        if (Input.GetKey("e"))
        {
            transform.Translate(0, 0, -speed * Time.smoothDeltaTime);
        }

    }
}
