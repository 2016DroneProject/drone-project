using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelAttack : MonoBehaviour {

    public GameObject player;
    public float TimeBetweenAttacks = 0.5f;
    public int AttackDamage = 10;

    private EelAgent eelAgent;
    private MonsterHP monsterHP;
    //PlayerHealth playerHealth;
    private Animator anim;
    private bool PlayerInRange;
    private float timer;

    void Awake()
    {
        eelAgent = GetComponent<EelAgent>();
        monsterHP = GetComponent<MonsterHP>();
        //playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 8f)
        {
            PlayerInRange = true;
        }
        else
        {
            PlayerInRange = false;
        }

        if (timer >= TimeBetweenAttacks && PlayerInRange && monsterHP.currentHP > 0)
        {
            eelAgent.state = EelAgent.State.ATTACK;
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    public void Attack()
    {
        Debug.Log("Eel Attack");
        timer = 0f;

        anim.SetBool("Attack", true);

        //if (playerHealth.currentHealth > 0)
        //{
        //    playerHealth.TakeDamage(m_iAttackDamage);
        //}
    }
}
