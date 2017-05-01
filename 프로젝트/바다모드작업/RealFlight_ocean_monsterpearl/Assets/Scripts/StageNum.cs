using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNum : MonoBehaviour {

    public int num;

    public int shell_num;

    public int pearl_num;

    public int score;

    GameObject score_text;

    AudioSource ac;

    Text scoretxt;

    GameObject Vaccum;
    GameObject Gun;

    private static StageNum s_Instance = null;


    public float altitude = 0;
    public int item = 0;
    public bool Attack = false;

    GameObject height;
    Text h_txt;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        score_text = GameObject.Find("Score");
        scoretxt = score_text.GetComponent<Text>();
        Vaccum = GameObject.Find("Vaccum");
        Gun = GameObject.Find("RightGun");
        height = GameObject.Find("Height");
        h_txt = height.GetComponent<Text>();
            

		
	}
	
	// Update is called once per frame
	void Update () {
        scoretxt.text = "Score: " + score;
        h_txt.text = "HEIGHT"+" \n" + altitude + " M";


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

        if(Attack == true)
        {
            Gun.SendMessage("Shotboolean");
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

    void AttackBat()
    {
        score += 250;
    }

    void AttackShark()
    {
        score += 500;
    }

    void OnApplicationQuit()
    {
        s_Instance = null;
        //게임종료시 삭제. 
    }
}
