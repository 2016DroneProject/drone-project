using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyUnitTarget : MonoBehaviour {

    private Unit unitScript;

    void Awake()
    {
        unitScript = this.gameObject.GetComponent<Unit>();
    }

    void Start()
    {
        unitScript.target = GameObject.FindWithTag("BaseBuilding");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HpUnit" || other.gameObject.tag == "ArmorUnit" || other.gameObject.tag == "AttkUnit" || other.gameObject.tag == "BaseBuilding")
        {
            unitScript.target = other.gameObject;

            if(unitScript.CheckRange())
            {
                unitScript.ChangeState(State_Attack.Instance);
            }
            else
            {
                unitScript.ChangeState(State_Move.Instance);
            }
        } 
        else
        {
            return;
        }
    }
}
