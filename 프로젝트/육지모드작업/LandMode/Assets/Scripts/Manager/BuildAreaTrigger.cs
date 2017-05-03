using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAreaTrigger : MonoBehaviour {

    public bool isVisibleBuilding;

    void Start()
    {
        isVisibleBuilding = false;
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RotRock" || other.gameObject.tag == "logs" || other.gameObject.tag == "bricks")
        {
            Debug.Log("build");
            Destroy(other.gameObject);
            isVisibleBuilding = true;
        }
    }
}
