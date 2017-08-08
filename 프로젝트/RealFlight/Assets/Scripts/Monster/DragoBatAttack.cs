using UnityEngine;
using System.Collections;

public class DragoBatAttack : MonoBehaviour {

    public float TimeBetweenAttacks = 0.5f;
    public int AttackDamage = 5;

    private GameObject player;
    private DragonBatAgent dragonBatAgent;
    private MonsterHP monsterHP;
    //private PlayerHP playerHP;
    private Animator anim;
    private Quaternion angle;
    private Vector3 target;
    private bool Alive;
    private bool PlayerInRange;
    private float timer;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        dragonBatAgent = GetComponent<DragonBatAgent>();
        monsterHP = GetComponent<MonsterHP>();
        //playerHP = player.GetComponent<PlayerHP>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        angle = transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //playerHealth.TakeDamage(m_iAttackDamage);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 10f)
            PlayerInRange = true;
        
        else if (distance > 10f)
            PlayerInRange = false;

        if (timer >= TimeBetweenAttacks && PlayerInRange && monsterHP.currentHP > 0)
        {
            dragonBatAgent.state = DragonBatAgent.State.ATTACK;
            anim.SetFloat("Speed", 0f);
        }
        else
        {
            transform.rotation = angle;
            dragonBatAgent.state = DragonBatAgent.State.PATROL;
            anim.SetFloat("Speed", dragonBatAgent.Speed);
        }
    }

    public void Attack()
    {
        target = player.transform.position;
        transform.LookAt(target);
        int num = Random.Range(0, 3);

        switch(num){
            case 0: {
                    anim.SetTrigger("Attack01");
                }
                break;
            case 1:
                {
                    anim.SetTrigger("Attack02");                   
                }
                break;
            case 2:
                {
                    anim.SetTrigger("Attack03");                
                }
                break;
        }
    }
}
