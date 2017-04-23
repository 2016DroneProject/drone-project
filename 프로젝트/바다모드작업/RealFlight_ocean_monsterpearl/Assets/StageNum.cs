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
    Text scoretxt;
    // Use this for initialization
    void Start () {
        score_text = GameObject.Find("Score");
        scoretxt = score_text.GetComponent<Text>();

		
	}
	
	// Update is called once per frame
	void Update () {
        scoretxt.text = "점수: " + score; 


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
}
