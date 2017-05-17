using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Move : FSM_State<Unit> {

    static readonly State_Move instance = new State_Move();


    public static State_Move Instance
    {
        get
        {
            return instance;
        }
    }

    private float resetTime = 3f;
    private float currentTime;

    public override void EnterState(Unit unit)
    {
        currentTime = resetTime;
    }

    public override void UpdateState(Unit unit)
    {
        //if (unit.CurrentHP <= 0)
        //{
        //    unit.ChangeState(State_Die.Instance);
        //}

        
        if(unit.target != null)
        {
            if(!unit.CheckRange())
            {
                //unit.ChaseTime += Time.deltaTime;
                //if(unit.ChaseTime >= unit.ChaseCancleTime)
                //{
                //    unit.target = null;
                //    unit.ChaseTime = 0f;
                //    return;
                //}

                Vector3 dir = unit.target.transform.position - unit.transform.position;
                Vector3 norDir = dir.normalized;

                Quaternion angle = Quaternion.LookRotation(norDir);

                unit.transform.rotation = angle;

                Vector3 pos = unit.transform.position;
                pos += unit.transform.forward * Time.smoothDeltaTime * unit.Speed;
                unit.transform.position = pos;
            }
            else
            {
                unit.ChangeState(State_Attack.Instance);
            }
        }
        else
        {
            unit.ResetState();
            //SetRandDir(unit);

            //Vector3 endPoint = unit.transform.position + (unit.transform.forward * 2f);

            //Vector3 pos = unit.transform.position;
            //pos += unit.transform.forward * Time.smoothDeltaTime * (unit.Speed / 3f);
            //unit.transform.position = pos;
        }
        
        // 날라댕기는 애니메이션
        unit.GetComponent<Animator>().SetBool("Fly Forward",true);
    }

    public override void ExitState(Unit unit)
    {
        Debug.Log("State-Move탈출");
        unit.GetComponent<Animator>().SetBool("Fly Forward", false);
    }

    void SetRandDir(Unit unit)
    {
        currentTime += Time.smoothDeltaTime;
        if(currentTime >= resetTime)
        {
            unit.transform.forward = Quaternion.AngleAxis(UnityEngine.Random.Range(0f, 360f), Vector3.up) * Vector3.forward;
            resetTime = UnityEngine.Random.Range(1f, 4f);
            currentTime = 0f;
        }
    }

}
