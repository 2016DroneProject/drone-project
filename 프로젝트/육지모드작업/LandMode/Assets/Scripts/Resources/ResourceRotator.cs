using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRotator : MonoBehaviour {

    private Quaternion angles;
    private float speed;
    private float acceleration;

    void Start () {
        speed = 1f;
        int num = Random.Range(0, 2);

        switch (num)
        {
            case 0:
                {
                    angles.eulerAngles = new Vector3(180f, 0f, 0f);
                }
                break;
            case 1:
                {
                    angles.eulerAngles = new Vector3(0f, 180f, 0f);
                }
                break;
            case 2:
                {
                    angles.eulerAngles = new Vector3(0, 0f, 180f);
                }
                break;
        }
	}


    void Update()
    {
        acceleration += speed;
        this.transform.Rotate(angles.eulerAngles, acceleration * Time.deltaTime, Space.Self);

    }
}
