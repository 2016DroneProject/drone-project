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
    public Managetext2 save_score;

    public Text myrank;
    public Text myscore;


    void Start()
    {
        tex = GetComponent<Text>();
        stage = GameObject.Find("UDP");
        score = stage.GetComponent<Order>();
        save_score.writing(score.Sea_Score);
        UnityEditor.AssetDatabase.Refresh();
        save_score.reading();
        myrank.text = save_score.myrank;
        myscore.text = score.Sea_Score.ToString();

    }

   
}
