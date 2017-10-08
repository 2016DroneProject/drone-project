using UnityEngine;
using System.Collections;

public class moveCloud : MonoBehaviour {
	public float speed;
	private Vector3 origin;
	// Use this for initialization
	void Start () {
		origin = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += new Vector3 (0.0f, speed * Time.deltaTime, 0.0f);
		if (0.0f < transform.localPosition.y) {
			transform.localPosition = origin;
		}
	}
}
