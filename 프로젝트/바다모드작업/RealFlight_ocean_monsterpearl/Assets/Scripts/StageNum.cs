using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNum : MonoBehaviour {

    public GameObject Gun;
    public int num;

    public int shell_num;

    public int pearl_num;

    public int score;

    public int eel_num;
    public int shark_num;

    Text eelnum;
    Text sharknum;

    GameObject score_text;

    AudioSource ac;

    Text scoretxt;

    GameObject Vaccum;

    GameObject height;
    Text h_txt;
    GameObject UDP;
    Order udporder;

    // Use this for initialization
    void Start () {

        eelnum = GameObject.Find("EelNum").GetComponent<Text>();
        sharknum = GameObject.Find("SharkNum").GetComponent<Text>();

        UDP = GameObject.Find("UDP");
        udporder = UDP.GetComponent<Order>();

        score_text = GameObject.Find("Score");
        scoretxt = score_text.GetComponent<Text>();
        Vaccum = GameObject.Find("Vaccum");

        height = GameObject.Find("Height");
        h_txt = height.GetComponent<Text>();

        score = udporder.Sea_Score;



    }
	
	// Update is called once per frame
	void Update () {
        scoretxt.text = "Score: " + score;
        h_txt.text = "HEIGHT"+" \n" + udporder.rcvPack.altitude + " M";
        eelnum.text = eel_num + "";
        sharknum.text = shark_num + "";

        udporder.Sea_Score = score;

        if (num == 1)
        {
            Vaccum.SetActive(true);
            Gun.SetActive(false);

        }

        else
        {
            Gun.SetActive(true);
            Vaccum.SetActive(false);
        }

        if(udporder.rcvPack.bAttack == true)
        {
            Gun.SendMessage("Shotboolean");
            udporder.rcvPack.bAttack = false;
        }

    }

    void stageone()    
    {
        num = 1;
    }

    void stagetwo()
    {
        num = 2;
    }

    void stagethree()
    {
        num = 3;
    }

    void stagefour()
    {
        num = 4;
    }

    void AddShell()
    {
        shell_num++;
        score += 10;
    }

    void AddPearl()
    {
        pearl_num++;
        score += 30;
    }

    void AttackEel()
    {
        eel_num++;
        score += 250;
    }

    void AttackShark()
    {
        shark_num++;
        score += 500;
    }

   
}
