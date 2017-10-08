using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToBuild : MonoBehaviour {

    public Vector3 buildPos;

	void Update () {

        RaycastHit hit;

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            if (hit.collider.tag == "BuildArea")
            {
                Debug.Log("빌드");
                buildPos = hit.point;

            }
        }

	}
}
