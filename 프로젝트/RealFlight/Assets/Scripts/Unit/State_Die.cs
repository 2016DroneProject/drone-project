using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Die :FSM_State<Unit> {

    static readonly State_Die instance = new State_Die();
    public static State_Die Instance
    {
        get
        {
            return instance;
        }
    }
    private float count = 2f;
    private float time = 0f;

    static State_Die() { }
    private State_Die() { }

    public override void EnterState(Unit unit)
    {
        // 죽는 애니메이션 추가
        unit.IsDead = true;
        unit.GetComponent<Animator>().SetTrigger("Die");
    }

    public override void UpdateState(Unit unit)
    {
        time += Time.deltaTime;

        if(unit.isActiveAndEnabled && time >= count)
        {
            unit.gameObject.SetActive(false);
            time = 0f;
        }
    }

    public override void ExitState(Unit unit)
    {
        
    }
}
