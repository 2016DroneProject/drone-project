using UnityEngine;
using System.Collections;

public class logoControl : MonoBehaviour {
	RectTransform rect;
	float width,height;

	public float speed = 1;
	public float maxDistance = 4;
	public float minDistance = -4;
	public float offset = 10;
	// Use this for initialization
	void Start () {
		//transform.localPosition.y = offset;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += new Vector3 (0, speed * Time.deltaTime, 0);
		if (transform.localPosition.y < minDistance) {
			//Debug.Log ("min");
			speed *= -1.0f;
		} else if (maxDistance < transform.localPosition.y) {
			speed *= -1.0f;
			//Debug.Log ("max");
		}
	}
}
