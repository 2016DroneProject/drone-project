using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellCount : MonoBehaviour {

    Text text;

    GameObject stage;
    StageNum num;


	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        stage = GameObject.Find("StageNum");
        num = stage.GetComponent<StageNum>();
        
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "조개: " + num.shell_num;
		
	}




}
