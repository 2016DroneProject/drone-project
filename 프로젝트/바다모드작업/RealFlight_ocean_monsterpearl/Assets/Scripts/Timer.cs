using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {

    Text RemainTime;
    public float TimeCount;
    int minute;
    int second;

    GameObject stage;
    StageNum score;

    public GameObject end;
	// Use this for initialization
	void Start () {
        RemainTime = GetComponent<Text>();
        
        stage = GameObject.Find("StageNum");
        score = stage.GetComponent<StageNum>();

		
	}
	
	// Update is called once per frame
	void Update () {

        if (TimeCount > 0.1f)
        {
            TimeCount -= Time.deltaTime;
            int timecalculate = (int)TimeCount;
            minute = timecalculate / 60;
            second = timecalculate % 60;
            RemainTime.text = "남은 시간: " + minute + "분 " + second + "초";
        }

        else
        {
            TimeCount = 0;
            end.SetActive(true);

            Destroy(this.gameObject, 0.1f);

        }
		
	}


}
