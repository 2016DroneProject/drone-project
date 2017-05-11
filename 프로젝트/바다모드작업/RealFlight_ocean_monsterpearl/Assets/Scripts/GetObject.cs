using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour {

    GameObject player;

    public float dist;



    GameObject target;
    SpawnShell make;

    int check = 0;

    GameObject targetCheck;
    BoxCollider box;

    AudioSource ac;

    public GameObject stars;
    LODGroup lod;

    GameObject shellnum;

    int num = 0;
    public AudioClip audioc;

    void Start()
    {

        shellnum = GameObject.Find("StageNum");
        player = GameObject.Find("CameraTarget");
        target = GameObject.Find("ImageTarget1");
        targetCheck = GameObject.Find("TargetCheck1");
        box = targetCheck.GetComponent<BoxCollider>();

        make = target.GetComponent<SpawnShell>();

        ac = this.gameObject.GetComponent<AudioSource>();
        lod = this.GetComponent<LODGroup>();
        //Debug.Log(player);
        //Debug.Log("dd" + target);

    }

    void Update()
    {
        if (box.enabled == true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < dist)
            {
                if (num < 1)
                {
                    ac.Play();
                    num++;
                }
                transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * 100f);
                
                if(transform.localScale.x > 0.3f && Vector3.Distance(transform.position, player.transform.position) < 30)
                    transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //Debug.Log("충돌함");
            lod.enabled = false;
            if (check == 0)
            {

                GetComponent<AudioSource>().clip = audioc;
                GetComponent<AudioSource>().Play();

                foreach (Transform child in transform)
                {
                    if(child.tag == "Shell")
                        child.GetComponent<MeshRenderer>().enabled = false;
                }
                shellnum.SendMessage("AddShell");
                stars.SetActive(true);
                make.makeShell();
                check++;
               // Debug.Log("만들어짐");

            }
           // Debug.Log("없어짐");
            Destroy(this.gameObject,1f);
        }
    }

    
}
