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
    private SkinnedMeshRenderer render;
    private Animator anim;
    private CapsuleCollider capsuleCollider;
    private Material material;
    //GameObject MonNum;
    //GameObject MonNum2;

    //monster_num MN;
    //monster2_num MN2;


    private float m_fAlpha = 1f;

    GameObject score;
    GameObject makebat;
    GameObject makeshark;

    int num = 0;

    void Awake()
    {
        //dragonbatAgent = GetComponent<DragonBatAgent>();
        //MonNum = GameObject.Find("Monster_Num");
        //MN = MonNum.GetComponent<monster_num>();

        //MonNum2 = GameObject.Find("Monster2_Num");
        //MN2 = MonNum2.GetComponent<monster2_num>();


        render = GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();

        score = GameObject.Find("StageNum");
        makebat = GameObject.Find("ImageTarget3");
        makeshark = GameObject.Find("ImageTarget4");
    }

    void Start()
    {
        currentHP = startingHP;
    }

    void Update()
    {
        if (IsVanish)
        {
            m_fAlpha -= 0.02f;

            Color maintain = render.material.color;

            render.material.color = new Color(maintain.r, maintain.g, maintain.b, m_fAlpha);

            
        }

    }

    public void TakeDamage(int amount)
    {
        // Debug.Log("Enemy Damaged");

        GameObject making;
        making = Instantiate(hitParticle, new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z), hitParticle.transform.rotation);
        making.transform.parent = this.transform;

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

        else if (this.gameObject.tag == "Shark")
        {
            GetComponent<AudioSource>().clip = BatdamagedClip;
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
                        GameObject makingred;
                        makingred = Instantiate(redDeadParticle, new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z), Quaternion.identity);
                        makingred.transform.parent = this.transform;
                        break;
                    }
                case 1:
                    {
                        GameObject makingblue ;
                        makingblue = Instantiate(blueDeadParticle, new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z), Quaternion.identity);
                        makingblue.transform.parent = this.transform;
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
            if(num == 0)
            {
                score.SendMessage("AttackBat");
                makebat.SendMessage("makeBat");
                num++;
            }
          
            
        }

        else if (this.gameObject.tag == "Eel")
        {
            if (num == 0)
            {
                score.SendMessage("AttackEel");
                makebat.SendMessage("makeEel");
                num++;
            }
        }

        else if (this.gameObject.tag == "Shark")
        {
            if (num == 0)
            {
                score.SendMessage("AttackShark");
                makeshark.SendMessage("makeBat");
                num++;
            }
        }

        GetComponent<Rigidbody>().isKinematic = true;

        Destroy(gameObject, 0.7f);
    }
}
