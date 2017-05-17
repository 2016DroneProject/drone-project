using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndUI : MonoBehaviour {

    float TimeCount;
    Text tex;

    GameObject stage;
    Order score;

    Timer timer;


    // Use this for initialization
    void Start () {
        tex = GetComponent<Text>();
        stage = GameObject.Find("UDP");
        score = stage.GetComponent<Order>();

    }
	
	// Update is called once per frame
	void Update () {

       


        tex.text = "Sea Mode1 Finished\n" + "My Score: " + score.Sea_Score;
       

      

    }
}
