using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage2 : MonoBehaviour {

    public int score;

    GameObject score_text;

    AudioSource ac;

    Text scoretxt;

    GameObject Gun;

    GameObject height;
    Text h_txt;
    GameObject UDP;
    Order udporder;

    // Use this for initialization
    void Start()
    {

        UDP = GameObject.Find("UDP");
        udporder = UDP.GetComponent<Order>();

        score_text = GameObject.Find("Score");
        scoretxt = score_text.GetComponent<Text>();
        Gun = GameObject.Find("RightGun");
        height = GameObject.Find("Height");
        h_txt = height.GetComponent<Text>();

        score = 0;



    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "Score: " + score;
        h_txt.text = "HEIGHT" + " \n" + udporder.rcvPack.altitude + " M";


        udporder.Sea_Score = score;

     
        if (udporder.rcvPack.bAttack == true)
        {
            Gun.SendMessage("Shotboolean");
            udporder.rcvPack.bAttack = false;
        }

    }
}
