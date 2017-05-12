using UnityEngine;
using System.Collections;

public class openning : MonoBehaviour {
    //public GameObject[] cloud;

    private bool startAnimation;
	private bool rotateCamera;
	public float moveTime = 3.0f;
	private float time;
	public GameObject destination;
	public float speed = 1.0f;

    bool isConnect;

	void Update () {
        
		if (startAnimation) {
			if (!rotateCamera) {
				time += Time.deltaTime;
				transform.Rotate (new Vector3 (0, 0, speed));
				if (moveTime < time) {
					//Vector3.MoveTowards (transform.position, destination.transform.position * 10.0f, 1.0f);
					transform.position += new Vector3 (destination.transform.position.x,destination.transform.position.y,destination.transform.position.z) * Time.deltaTime * 2.0f;
				}
			}
		}
	}
	void startAni(){
		startAnimation = true;
	}
}
