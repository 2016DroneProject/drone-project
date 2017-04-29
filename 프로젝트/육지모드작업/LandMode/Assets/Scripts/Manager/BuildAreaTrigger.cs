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
        if(other.gameObject.name == "RotRock" || other.gameObject.name == "RotLog" || other.gameObject.name == "RotBrick")
        {
            Destroy(other.gameObject);
            isVisibleBuilding = true;
        }
    }
}
