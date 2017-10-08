using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour {

    GameObject timer_text;
    Timer timer;

    float count;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        timer_text = GameObject.Find("Timer");
        timer = timer_text.GetComponent<Timer>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(count > 5f)
        {
            timer.enabled = true;
            Destroy(this.gameObject);
        }

        count += Time.deltaTime;
	}
}
