using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelAgent : MonoBehaviour {

    public GameObject player;
    public GameObject[] wayPoints;
    public float Speed;
    public float ChaseSpeed;

    public enum State
    {
        PATROL,
        CHASE,
        ATTACK
    }

    public State state;

    private Animator anim;
    //PlayerMove playerMove;
    private EelAttack eelAttack;
    private MonsterHP monsterHP;
    private Vector3 target;
    private int WayPointInd = 0;

    void Awake()
    {
        anim = GetComponent<Animator>();
        //playerMove = player.GetComponent<PlayerMove>();
        //eelAttack = GetComponent<EelAttack>();
        monsterHP = GetComponent<MonsterHP>();
    }

    void Start()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("EELWP");
        WayPointInd = Random.Range(0, wayPoints.Length);
        StartCoroutine("EnemyFSM");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 20f && transform.position.y <= player.transform.position.y + 3.5f && transform.position.y >= player.transform.position.y)
        {
            //if (playerMove.isUnderWater)
                state = State.CHASE;
        }
        else
        {
            state = State.PATROL;
        }
    }

    IEnumerator EnemyFSM()
    {
        while (!monsterHP.IsDead)
        {
            switch (state)
            {
                case State.PATROL:
                    {
                        PatrolAgent();
                        break;
                    }
                case State.CHASE:
                    {
                        Chase();
                        break;
                    }
                case State.ATTACK:
                    {
                        eelAttack.Attack();
                        break;
                    }
            }
            yield return null;
        }
    }

    void PatrolAgent()
    {
        anim.SetFloat("Speed", Speed);

        target = wayPoints[WayPointInd].transform.position;

        if (Vector3.Distance(transform.position, wayPoints[WayPointInd].transform.position) >= 0.6f)
        {
            anim.SetFloat("Speed", Speed);
            transform.LookAt(target);
            transform.Rotate(new Vector3(0, 180, 0));
            transform.Translate(-Vector3.forward * Speed * Time.smoothDeltaTime);
        }
        else if (Vector3.Distance(transform.position, wayPoints[WayPointInd].transform.position) <= 0.6f)
        {
            WayPointInd = Random.Range(0, wayPoints.Length);
        }
    }

    void Chase()
    {
        Speed = ChaseSpeed;
        anim.SetFloat("Speed", Speed);
        transform.LookAt(player.transform.position);
        transform.Rotate(new Vector3(0, 180, 0));
        transform.Translate(-Vector3.forward * Speed * Time.smoothDeltaTime);
    }
}
