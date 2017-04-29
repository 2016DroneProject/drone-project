using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInit : MonoBehaviour
{


    void Start()
    {
        this.transform.rotation = Quaternion.AngleAxis(-90f, new Vector3(1f, 0f, 0f));
    }
}

