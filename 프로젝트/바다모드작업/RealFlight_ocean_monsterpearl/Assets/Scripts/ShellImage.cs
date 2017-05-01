using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellImage : MonoBehaviour {

    GameObject ImageT;

    RectTransform shell_img;

	// Use this for initialization
	void Start () {
        ImageT = GameObject.Find("ImageT");
        shell_img = ImageT.GetComponent<RectTransform>();
        Debug.Log(ImageT.GetComponent<RectTransform>().position);
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(this.transform.position, shell_img.transform.position, Time.deltaTime);
        Debug.Log(ImageT.GetComponent<RectTransform>().position);


    }
}
