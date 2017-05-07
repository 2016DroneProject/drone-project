using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour {

    private Rigidbody rb;
    public float power;

    int num = 0;
    GameObject manager;
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody>();

        Destroy(this.gameObject, 10f);

    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(-this.transform.up * power);

    }

    private void OnTriggerEnter(Collider other)
    {
        Mission mis = manager.GetComponent<Mission>();

        if (other.tag == "Box" || other.tag == "Pack" || other.tag == "Potion" || other.tag == "Gold" || other.tag == "Bill" || other.tag == "MoneyBag" || other.tag == "SilverCoin" || other.tag == "GoldCoin" || other.tag == "Gem")
        {
            

            if (num == 0)
            {
                //Debug.Log("박스닷");
                other.SendMessage("bool_change");

                if (mis.now_mission1 == other.tag)
                {
                    mis.now_mission1 = null;
                    mis.now_mission1 = "Clear";
                    other.SendMessage("desbool");

                    if (mis.now_mission2 == "Clear")
                        mis.nextstage();
                }

                else if (mis.now_mission2 == other.tag)
                {
                    mis.now_mission2 = null;
                    mis.now_mission2 = "Clear";
                    other.SendMessage("desbool");
                    if (mis.now_mission1 == "Clear")
                        mis.nextstage();
                }

                num++;
                Destroy(this.gameObject, 2f);
            }

         

        }

       
    }
}
