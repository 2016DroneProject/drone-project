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

    public GameObject bar;
    Image barimg;
    float saveTime;
	// Use this for initialization
	void Start () {
        RemainTime = GetComponent<Text>();
        
        stage = GameObject.Find("StageNum");
        score = stage.GetComponent<StageNum>();
        barimg = bar.GetComponent<Image>();
        saveTime = TimeCount;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (TimeCount > 0.1f)
        {
            TimeCount -= Time.deltaTime;
            int timecalculate = (int)TimeCount;
            RemainTime.text = "Time: "+ timecalculate;

            barimg.fillAmount = timecalculate / saveTime;
        }

        else
        {
            TimeCount = 0;
            end.SetActive(true);

            Destroy(this.gameObject, 0.1f);

        }
		
	}


}
