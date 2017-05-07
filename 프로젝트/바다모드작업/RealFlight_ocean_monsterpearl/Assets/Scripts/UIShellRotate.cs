using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShellRotate : MonoBehaviour {

    int minus = 1;

    void Start()
    {

    }

    void Update()
    {
        if (transform.rotation.z > 0.2)
        {
            minus = -1;
        }
        else if (transform.rotation.z < -0.2)
        {
            minus = 1;
        }
        transform.Rotate(0, 0, 1 * Time.timeScale * minus, 0);
    }
}
