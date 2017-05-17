using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAreaTrigger : MonoBehaviour {

    public bool isVisibleBuilding_armor;
    public bool isVisibleBuilding_hp;
    public bool isVisibleBuilding_attk;

    void Start()
    {
        isVisibleBuilding_armor = false;
        isVisibleBuilding_hp = false;
        isVisibleBuilding_attk = false;
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RotRock")
        {
            Destroy(other.gameObject);
            isVisibleBuilding_armor = true;
        }
        else if (other.gameObject.tag == "logs")
        {
            Destroy(other.gameObject);
            isVisibleBuilding_attk = true;
        }
        else if(other.gameObject.tag == "bricks")
        {
            Destroy(other.gameObject);
            isVisibleBuilding_hp = true;
        }
    }
}
