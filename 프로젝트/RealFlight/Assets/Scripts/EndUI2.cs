using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndUI2 : MonoBehaviour {

    float TimeCount;
    Text tex;

    GameObject stage;
    Order score;

    Timer timer;
    float count;

    // Use this for initialization
    void Start()
    {
        tex = GetComponent<Text>();
        stage = GameObject.Find("UDP");
        score = stage.GetComponent<Order>();

    }

    // Update is called once per frame
    void Update()
    {


        tex.text = "Sea Mode GameOver\n" + "My Score: " + score.Sea_Score;




    }
}
