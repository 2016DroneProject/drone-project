using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCheck : MonoBehaviour {

    BoxCollider col;

    GameObject stagenum;

    public int num;
	// Use this for initialization
	void Start () {
        stagenum = GameObject.Find("StageNum");
        col = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {

        if(col.enabled == true)
        {

            if(num == 1)
                stagenum.SendMessage("stageone");

            else if (num == 2)
                stagenum.SendMessage("stagetwo");

            else if (num == 3)
                stagenum.SendMessage("stagethree");

            else if (num == 4)
                stagenum.SendMessage("stagefour");
        }
		
	}
}
