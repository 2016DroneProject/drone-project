using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootingStart : MonoBehaviour {

    public GameObject pearl;
    Transform shotPos;


    Order udpconnect;

    AudioSource ac;

    // Use this for initialization
    void Start () {
        shotPos = GameObject.Find("Shotpos").transform;
        udpconnect = GameObject.Find("UDP").GetComponent<Order>();
        ac = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(udpconnect.rcvPack.bAttack == true || Input.GetMouseButtonDown(0))
        {
            ShootPearl();
            udpconnect.rcvPack.bAttack = false;
        }
		
	}

    void ShootPearl()
    {
        //
        ac.Play();

        // 진주 발사 부분

        Instantiate(pearl, shotPos.position, pearl.transform.rotation);
    }



}
