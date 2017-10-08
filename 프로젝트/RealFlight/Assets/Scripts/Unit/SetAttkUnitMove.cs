using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttkUnitMove : MonoBehaviour {

    void Start()
    {
        this.enabled = false;
    }

	void Update () {
        Vector3 dir = this.GetComponent<Unit>().target.transform.position - this.transform.position;
        Vector3 norDir = dir.normalized;

        Quaternion angle = Quaternion.LookRotation(norDir);

        this.transform.rotation = angle;

        Vector3 pos = this.transform.position;
        pos += this.transform.forward * Time.smoothDeltaTime * this.GetComponent<Unit>().Speed;
        this.transform.position = pos;
    }
}
