using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea2UIManager : MonoBehaviour {

    public GameObject gun;
    public GameObject timer;
    public GameObject stagenum;
    public GameObject mission;

    public GameObject[] inform = new GameObject[7];

    Order ord;
    int num = 0;
    public GameObject[] target = new GameObject[4];

    // Use this for initialization
    void Start () {
        ord = GameObject.Find("UDP").GetComponent<Order>();
        timer.SetActive(false);
        gun.SetActive(false);
        //stagenum.SetActive(false);
        //mission.SetActive(false);
        //for (int i = 0; i < target.Length; i++)
        //{
        //    target[i].SetActive(false);
        //}

        inform[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (ord.rcvPack.bAttack == true || Input.GetMouseButtonDown(0))
        {

            inform[num].SetActive(false);

            num++;

            if (num > 6)
            {
                //for (int i = 0; i < target.Length; i++)
                //{
                //    target[i].SetActive(true);
                //}
                timer.SetActive(true);
                gun.SetActive(true);
                //stagenum.SetActive(true);
                //mission.SetActive(true);
                Destroy(this.gameObject);
            }

            else
                inform[num].SetActive(true);

            ord.rcvPack.bAttack = false;
        }
    }
}
