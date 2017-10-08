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
    public managertext save_score;

    public Text myrank;
    public Text myscore;

    // Use this for initialization
    void Start () {
        tex = GetComponent<Text>();
        stage = GameObject.Find("UDP");
        score = stage.GetComponent<Order>();
        save_score.writing(score.Sea_Score);
        UnityEditor.AssetDatabase.Refresh();
        save_score.reading();
        myrank.text = save_score.myrank;
        myscore.text = score.Sea_Score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
  

    }
}
