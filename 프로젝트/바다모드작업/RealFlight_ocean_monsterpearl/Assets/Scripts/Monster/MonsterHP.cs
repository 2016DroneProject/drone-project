using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour {

    public GameObject redDeadParticle;
    public GameObject blueDeadParticle;
    public GameObject hitParticle;

    public AudioClip BatdamagedClip;
    public AudioClip EeldamagedClip;
    public AudioClip deathClip;

    public int startingHP = 100;
    public int currentHP;
    public bool IsVanish;
    public bool IsDead;

    //private DragonBatAgent dragonbatAgent;
    private SkinnedMeshRenderer renderer;
    private Animator anim;
    private CapsuleCollider capsuleCollider;
    private Material material;
    //GameObject MonNum;
    //GameObject MonNum2;

    //monster_num MN;
    //monster2_num MN2;


    private float m_fAlpha = 1f;

    void Awake()
    {
        //dragonbatAgent = GetComponent<DragonBatAgent>();
        //MonNum = GameObject.Find("Monster_Num");
        //MN = MonNum.GetComponent<monster_num>();

        //MonNum2 = GameObject.Find("Monster2_Num");
        //MN2 = MonNum2.GetComponent<monster2_num>();


        renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
    }

    void Start()
    {
        currentHP = startingHP;
    }

    void Update()
    {
        if (IsVanish)
        {
            m_fAlpha -= 0.005f;
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.b, renderer.material.color.g, m_fAlpha);
        }

    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Enemy Damaged");

        Instantiate(hitParticle, this.transform.position, hitParticle.transform.rotation);

        if (this.gameObject.tag == "Bat")
        {
            GetComponent<AudioSource>().clip = BatdamagedClip;
            GetComponent<AudioSource>().Play();
        }

        else if (this.gameObject.tag == "Eel")
        {
            GetComponent<AudioSource>().clip = EeldamagedClip;
            GetComponent<AudioSource>().Play();
        }

        if (IsDead)
            return;

        currentHP -= amount;

        anim.SetTrigger("Damaged");


        if (currentHP <= 0)
        {
            int select = Random.Range(0, 2);
            switch (select)
            {
                case 0:
                    {
                        Instantiate(redDeadParticle, transform.position, Quaternion.identity);
                        break;
                    }
                case 1:
                    {
                        Instantiate(blueDeadParticle, transform.position, Quaternion.identity);
                        break;
                    }
            }

            Death();
        }

    }

    void Death()
    {
        IsDead = true;
        IsVanish = true;
        capsuleCollider.isTrigger = true;

        GetComponent<AudioSource>().clip = deathClip;
        GetComponent<AudioSource>().Play();

        anim.SetTrigger("Dead");

        if (this.gameObject.tag == "Bat")
        {
            //MN.num += 1;
        }

        else if (this.gameObject.tag == "Eel")
        {
            //MN2.n_eel += 1;
        }

        else if (this.gameObject.tag == "Shark")
        {
            //MN2.n_shark += 1;
        }

        GetComponent<Rigidbody>().isKinematic = true;

        Destroy(gameObject, 3.5f);
    }
}
