using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreManager : MonoBehaviour {

    float TimeCount;
    Text tex;

    GameObject stage;
    Order score;

    Timer timer;
    public managertext3 save_score;

    public Text myrank;
    public Text myscore;

    void Start()
    {
        tex = GetComponent<Text>();
        stage = GameObject.Find("UDP");
        score = stage.GetComponent<Order>();
        save_score.writing(score.Land_Score);
        UnityEditor.AssetDatabase.Refresh();
        save_score.reading();
        myrank.text = save_score.myrank;
        myscore.text = score.Land_Score.ToString();
    }

}
