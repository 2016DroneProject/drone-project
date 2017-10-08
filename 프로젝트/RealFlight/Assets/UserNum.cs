using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserNum : MonoBehaviour {
    float TimeCount;
    public GameObject timer;

    public Text time_count;
    public Text inform;

    public Parse numtext;

    // Use this for initialization
    void Start () {
        TimeCount = 6f;
        timer.SetActive(false);
        numtext.edittext();
        inform.text = "발급받은 ID는 USER " + numtext.user.ToString("D4") + "입니다. \n 해당 ID로 게임을 플레이할 수 있습니다.";

    }
	
	// Update is called once per frame
	void Update () {

        if (TimeCount < 0f)
        {
            TimeCount = 0;
            
            timer.SetActive(true);
         
            Destroy(this.gameObject);

        }

        time_count.text = (int)TimeCount + "";
        TimeCount -= Time.deltaTime;



    }
}
