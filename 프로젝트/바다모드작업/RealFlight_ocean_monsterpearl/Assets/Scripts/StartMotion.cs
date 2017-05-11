using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMotion : MonoBehaviour {
    float TimeCount;

    public GameObject ar_camera;
    public GameObject img;
    public GameObject open;
    public GameObject timer;

    // Use this for initialization
    void Start () {
        img.SetActive(true);
        ar_camera.SetActive(false);
        
        timer.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if(TimeCount > 3f)
        {
            open.SendMessage("startAni");
        }

        if (TimeCount > 6f)
        {
            ar_camera.SetActive(true);
   
            timer.SetActive(true);
            Destroy(img);
            Destroy(this.gameObject);

        }

      
        TimeCount += Time.deltaTime;
    }
}
