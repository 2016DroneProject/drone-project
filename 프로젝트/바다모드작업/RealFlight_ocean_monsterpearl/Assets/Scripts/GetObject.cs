using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour {

    GameObject player;

    public float dist;
    float min_dist;

    bool near;

    GameObject target;
    SpawnShell make;

    int check = 0;

    GameObject targetCheck;
    BoxCollider box;

    AudioSource ac;

    public GameObject stars;
    LODGroup lod;

    public GameObject mesh1;
    public GameObject mesh2;
    public GameObject mesh3;
    void Start()
    {

        min_dist = 2f;

        near = false;
        player = GameObject.Find("CameraTarget");
        target = GameObject.Find("ImageTarget");
        targetCheck = GameObject.Find("TargetCheck");
        box = targetCheck.GetComponent<BoxCollider>();

        make = target.GetComponent<SpawnShell>();

        ac = this.gameObject.GetComponent<AudioSource>();
        lod = this.GetComponent<LODGroup>();
        Debug.Log(player);
        Debug.Log("dd" + target);

    }

    void Update()
    {
        if (box.enabled == true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < dist)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * 120f);

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("충돌함");
            Destroy(mesh1);
            Destroy(mesh2);
            Destroy(mesh3);
            lod.enabled = false;
            if (check == 0)
            {
                
                ac.Play();
                stars.SetActive(true);
                make.makeShell();
                check++;
                Debug.Log("만들어짐");

            }
            Debug.Log("없어짐");
            
            Destroy(this.gameObject, 1f);
        }
    }

    
}
