using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour {

    void Update()
    {
        transform.Rotate(Vector3.up * 10.0f * Time.deltaTime);

    }
}
