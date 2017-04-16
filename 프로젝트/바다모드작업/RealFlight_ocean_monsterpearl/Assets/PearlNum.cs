using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PearlNum : MonoBehaviour {


  

    Text tex;


    GameObject stage;
    StageNum num;

    // Use this for initialization
    void Start () {
        tex = GetComponent<Text>();
        stage = GameObject.Find("StageNum");
        num = stage.GetComponent<StageNum>();

    }
	
	// Update is called once per frame
	void Update () {
        tex.text = "진주 : " + num.pearl_num;


    }


}
