//======================================
/*
@autor ktk.kumamoto
@date 2015.3.9 create
@note LookAt
*/
//======================================


using UnityEngine;
using System.Collections;


public class LookAt : MonoBehaviour {
	
	
	public Transform target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
	}
}