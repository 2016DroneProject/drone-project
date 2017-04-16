using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNum : MonoBehaviour {

    public int num;

    public int shell_num;

    public int pearl_num;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
    }

    void AddPearl()
    {
        pearl_num++;
    }
}
