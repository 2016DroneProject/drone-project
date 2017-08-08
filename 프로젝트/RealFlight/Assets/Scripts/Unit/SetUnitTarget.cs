using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnitTarget : MonoBehaviour {

    private Unit unitScript;

    void Awake()
    {
        unitScript = this.gameObject.GetComponent<Unit>();
    }

    void Start()
    {
        unitScript.target = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyUnit")
        {
            unitScript.target = other.gameObject;

            if (unitScript.CheckRange())
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
