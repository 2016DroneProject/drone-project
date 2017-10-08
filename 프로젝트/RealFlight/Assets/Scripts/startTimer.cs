using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startTimer : MonoBehaviour {

    public float counttime;


    Text tex;
	// Use this for initialization
	void Start () {
        tex = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
        
        counttime -= Time.deltaTime;
     
        tex.text = (int)counttime + "";

        if(counttime < 0f)
        {
            counttime = 0;

            Destroy(this.gameObject);
        }


    }
}
