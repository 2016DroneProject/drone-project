using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State_Attack : FSM_State<Unit> {

    static readonly State_Attack instance = new State_Attack();

    public static State_Attack Instance
    {
        get
        {
            return instance;
        }
    }

    private float AttackTimer = 0f;

    static State_Attack() {  }
    private State_Attack() { }

    public override void EnterState(Unit unit)
    {
        //
        if(unit.target == null)
        {
            return;
        }
        AttackTimer = unit.AttackSpeed;
    }

    public override void UpdateState(Unit unit)
    {
        if(unit.CurrentHP <= 0)
        {
           unit.ChangeState(State_Die.Instance);
        }

        AttackTimer += Time.deltaTime;

        
        if (unit.CheckRange()) // && !unit.target.IsDead && 
        {
            if (AttackTimer >= unit.AttackSpeed)
            {
                Debug.Log("attack");
                // 공격 애니메이션
                unit.GetComponent<Animator>().SetTrigger("Attack Bite");
                unit.target.GetComponent<Unit>().TakeDamaged(unit.AttackDamage);
                AttackTimer = 0f;
                unit.ChaseTime = 0f;
            }
        }
        else
        {
            unit.ChangeState(State_Move.Instance);
        }
        
    }

    public override void ExitState(Unit unit)
    {
        Debug.Log("State_Attack 탈출");
    }
}
