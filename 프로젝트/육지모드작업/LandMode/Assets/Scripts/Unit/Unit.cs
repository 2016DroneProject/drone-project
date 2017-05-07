using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public GameObject target;
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

    //private GameObject target;
    private Animator anim;
    private StateMachine<Unit> state = null;

    void Awake()
    {
        anim = GetComponent<Animator>();
        ResetState();
    }

    void Update()
    {
        state.Update();
    }

    public void ChangeState(FSM_State<Unit> State)
    {
        state.ChangeState(State);
    }

    public bool CheckRange()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) <= AttackRange)
        {
            Debug.Log("checkrange");
            return true;
        }
        return false;
    }

    public void ResetState()

    {
        CurrentHP = Hp;

        state = new StateMachine<Unit>();

        // 초기 상태 설정
        state.Init(this, State_Move.Instance);

        // 타겟 null 설정
        target = null;
    }

    public void TakeDamaged(int amount)
    {
        CurrentHP -= amount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            Debug.Log("목표");
            target = other.gameObject;

            if (CheckRange())

            {
                ChangeState(State_Attack.Instance);
            }
            else

            {
                ChangeState(State_Move.Instance);
            }
        }
        else
        {
            return;
        }
    }
}
