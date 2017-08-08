using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUnit : MonoBehaviour {

    public int Hp = 500;
    public int AttackDamage = 75;
    public int CurrentHP;
    public float AttackRange = 1f;
    public float AttackSpeed = 1.5f;
    public float ChaseCancleTime = 5f;
    public float ChaseTime = 0;
    public float Speed = 2.5f;
    public float DeadTimer = 0;
    public bool IsDead;

    private GameObject target;
    private Animator anim;
    private StateMachine<HpUnit> state = null;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {

    }

    public void ChangeState(FSM_State<HpUnit> State)
    {

    }

    public bool CheckRange()
    {
        //if(Vector3.Distance(target.transform.position, this.transform.position) <= AttackRange)
        //{
        //    return true;
        //}
        return false;
    }

    public void ResetState()
    {
        CurrentHP = Hp;
        IsDead = false;

        state = new StateMachine<HpUnit>();
        //state.Init(this,);
    }
}
