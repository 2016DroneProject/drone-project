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

    private Animator anim;
    private AudioSource audio;
    private StateMachine<Unit> state = null;

    void Awake()
    {
        target = null;
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = Resources.Load("Audios/5. UnitMovement") as AudioClip;
        audio.Play();
        ResetState();
    }

    void Update()
    {
        state.Update();

        if (CurrentHP <= 0)
        {
            IsDead = true;
            anim.SetTrigger("Die");
            audio.clip = Resources.Load("PAudios/6. UnitDeath") as AudioClip;
            audio.Play();
            this.gameObject.SetActive(false);
        }
    }

    public void ChangeState(FSM_State<Unit> State)
    {
        state.ChangeState(State);
    }

    public bool CheckRange()
    {
        if (this.gameObject.tag == "HpUnit" || this.gameObject.tag == "ArmorUnit" || this.gameObject.tag == "AttkUnit")
        {
            if (target.tag == "EnemyUnit" || target.tag == "EnemyBuilding")
            {
                if (Vector3.Distance(target.transform.position, this.transform.position) <= AttackRange)
                {
                    return true;
                }
            }
            else if(target == null)
            {
                ResetState();
            }
        }

        else if (this.gameObject.tag == "EnemyUnit")
        {
            if (target.tag == "HpUnit" || target.tag == "ArmorUnit" || target.tag == "AttkUnit" || target.tag == "BaseBuilding")
            {
                if (Vector3.Distance(target.transform.position, this.transform.position) <= AttackRange)
                {
                    return true;
                }
            }
            else if (target == null)
            {
                ResetState();
            }
        }   
        return false;
    }

    public void ControlledByPlayer()
    {
        target = GameObject.FindWithTag("EnemyBuilding");
    }

    public void ResetState()
    {
        CurrentHP = Hp;

        state = new StateMachine<Unit>();

        // 초기 상태 설정
        state.Init(this, State_Move.Instance);

        target = null;
    }

    public void TakeDamaged(int amount)
    {
        CurrentHP -= amount;
    }

 
}
