using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGunShooting : MonoBehaviour {

    public GameObject player;
    //public CubeMotionMoveSample motion;
    //public Mobile_Text_Mgr mtm;
    public float FireRate = .5f;
    public float FireRange = 500f;
    public int LaserDamage = 5;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.03f;

    private Vector3 originPos;
    private LineRenderer LaserLine;
    private WaitForSeconds m_LaserDuration = new WaitForSeconds(0.1f);
    private bool m_bLaserLineEnabled;
    private bool isGunshot;
    private float m_fNextFire;

    private void Awake()
    {
        LaserLine = GetComponent<LineRenderer>();
    }

    void Start()
    {
        LaserLine.enabled = false;
    }

    void OnEnable()
    {
        originPos = transform.localPosition;
    }

    void Update()
    {
        //isGunshot = mtm.rcvPack.GunShot;

        if (isGunshot && Time.time > m_fNextFire)
        {
            Fire();
            //mtm.rcvPack.GunShot = false;
        }
        else
        {
            shakeDuration = 0f;
        }

        if (shakeDuration > 0)
        {
            transform.localPosition = originPos + Random.insideUnitSphere * shakeAmount;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originPos;
        }
    }

    private void Fire()
    {
        //motion.isattack = true;
        //motion.Startsecond = 0;
        m_fNextFire = Time.time + FireRate;
        shakeDuration = 10f;


        RaycastHit hit;
        LaserLine.SetPosition(0, new Vector3(transform.position.x, transform.position.y - 22f, transform.position.z + 0.3f));

        if (Physics.Raycast(transform.position, player.transform.forward, out hit))
        {
            if (hit.collider)
            {
                MonsterHP monsterHP = hit.collider.gameObject.GetComponent<MonsterHP>();
                if (monsterHP != null)
                {
                    monsterHP.TakeDamage(LaserDamage);
                }
                LaserLine.SetPosition(1, new Vector3(transform.position.x, player.transform.position.y, transform.position.z + 0.3f));
                //if (monsterNum.num < 3)
                //{
                //    Instantiate(RedHitEffect, new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z), Quaternion.identity);
                //}

                //else if (monsterNum.num >= 3 && monsterNum.num < 6)
                //{
                //    Instantiate(GreenHitEffect, new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z), Quaternion.identity);
                //}
                //else if (monsterNum.num >= 6)
                //{
                //    Instantiate(BlueHitEffect, new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z), Quaternion.identity);
                //}
            }
        }
        else
        {
            LaserLine.SetPosition(1, new Vector3(transform.position.x, 0, FireRange));
        }

        StartCoroutine(Laser());
    }

    private IEnumerator Laser()
    {
        LaserLine.enabled = true;
        //if (monsterNum.num < 3)
        //{
        //    redParticle.SetActive(true);
        //}
        //else if (monsterNum.num >= 3 && monsterNum.num < 6)
        //{
        //    greenParticle.SetActive(true);
        //}
        //else if (monsterNum.num >= 6)
        //{
        //    blueParticle.SetActive(true);
        //}

        yield return m_LaserDuration;
        LaserLine.enabled = false;
        //redParticle.SetActive(false);
        //greenParticle.SetActive(false);
        //blueParticle.SetActive(false);
    }
}
