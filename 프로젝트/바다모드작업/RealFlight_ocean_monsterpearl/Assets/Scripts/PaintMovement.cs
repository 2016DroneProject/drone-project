using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMovement : MonoBehaviour {

    private Rigidbody rb;
    public float power;

    Mode2Manager mm;
	// Use this for initialization
	void Start () {
        mm = GameObject.Find("StageNum").GetComponent<Mode2Manager>();
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 10f);
    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(-this.transform.up * power);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Box" || other.tag == "Pack" || other.tag == "Potion" || other.tag == "Gold" || other.tag == "Bill" || other.tag == "MoneyBag" || other.tag == "SilverCoin" || other.tag == "GoldCoin" || other.tag == "Gem")
        {
            //Debug.Log("페인트 충돌");

            Renderer rend = other.GetComponent<Renderer>();
            rend.sharedMaterial = null;
            rend.sharedMaterial = mm.box_material[6 - mm.paint];
            Destroy(this.gameObject);
           
           
        }
    }
}
