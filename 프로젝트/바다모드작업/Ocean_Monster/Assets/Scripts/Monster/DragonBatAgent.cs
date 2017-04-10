using UnityEngine;
using System.Collections;

public class DragonBatAgent : MonoBehaviour {

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

    private GameObject player;
    private Animator anim;
    //private PlayerMove playerMove;
    private MonsterHP monsterHP;
    private DragoBatAttack dragonbatAttack;
    private Vector3 target;
    private int WayPointInd = 0;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        //playerMove = player.GetComponent<PlayerMove>();
        anim = GetComponent<Animator>();
        dragonbatAttack = GetComponent<DragoBatAttack>();
        monsterHP = GetComponent<MonsterHP>();
    }

    void Start()
    {
        //wayPoints = GameObject.FindGameObjectsWithTag("DragonBatWP");
        //WayPointInd = Random.Range(0, wayPoints.Length);
        StartCoroutine("DragonbatFSM");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 20f && distance > 6f)
        {
            //if (!playerMove.isUnderWater)
                state = State.CHASE;
        }
    }

    IEnumerator DragonbatFSM()
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
                        //if (!playerMove.isUnderWater)
                            dragonbatAttack.Attack();
                        break;
                    }
            }
            yield return null;
        }
    }

    void PatrolAgent()
    {
        anim.SetFloat("Speed", Speed);

        //target = wayPoints[WayPointInd].transform.position;

        //if (Vector3.Distance(transform.position, wayPoints[WayPointInd].transform.position) >= 0.6f)
        //{
        //    anim.SetFloat("Speed", Speed);
        //    transform.LookAt(target);
        //    transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime);
        //}
        //else if (Vector3.Distance(transform.position, wayPoints[WayPointInd].transform.position) <= 0.6f)
        //{
        //    WayPointInd = Random.Range(0, wayPoints.Length);
        //}
    }

    void Chase()
    {
        Speed = ChaseSpeed;
        anim.SetFloat("Speed", Speed);
        target = player.transform.position;
        transform.LookAt(target);
        transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime);
    }
}
