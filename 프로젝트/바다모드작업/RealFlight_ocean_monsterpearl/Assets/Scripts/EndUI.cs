using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndUI : MonoBehaviour {

    float TimeCount;
    Text tex;

    GameObject stage;
    StageNum score;

    Timer timer;
    float count;
    // Use this for initialization
    void Start () {
        tex = GetComponent<Text>();
        stage = GameObject.Find("StageNum");
        score = stage.GetComponent<StageNum>();

    }
	
	// Update is called once per frame
	void Update () {

        if (count > 5f)
        {
            //Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }


        tex.text = "겜끝\n" + "내점수: " + score.score;
       

        count += Time.deltaTime;

    }
}
