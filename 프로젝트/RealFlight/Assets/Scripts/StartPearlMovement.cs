using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPearlMovement : MonoBehaviour {

    private Transform shotPos;
    private Rigidbody rb;

    public float power = 10f;



    GameObject next;

    AudioSource ad;


    // Use this for initialization
    void Start () {
        next = GameObject.Find("MoveNextMode");
        shotPos = GameObject.Find("Shotpos").transform;
        rb = GetComponent<Rigidbody>();
        ad = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(shotPos.transform.forward * power);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        {
            ad.Play();
            next.SendMessage("nextstage", 2);
        }

        else if (other.tag == "Startfish")
        {
            ad.Play();
            next.SendMessage("nextstage", 1);
        }

        else if(other.tag == "Castle")
        {
            ad.Play();
            next.SendMessage("nextstage", 3);
        }
    }
}
