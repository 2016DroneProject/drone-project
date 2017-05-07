using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMovement : MonoBehaviour {

    Mode2Manager mm;
	// Use this for initialization
	void Start () {
        mm = GameObject.Find("StageNum").GetComponent<Mode2Manager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

    }
}
