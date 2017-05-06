using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEel : MonoBehaviour {


    public GameObject[] eel;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            makeEel();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void makeEel()
    {
        GameObject making;

        float x = Random.Range(-200.0f, 200.0f);
        float y = Random.Range(300.0f, 550.0f);
        float z = Random.Range(-120.0f, 120.0f);
        int w = Random.Range(-180, 180);

        //Debug.Log(w);

        int num = (int)Random.Range(0, 3);

        making = Instantiate(eel[num], new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
        making.transform.parent = transform;
        making.transform.Rotate(0, w, 0);


    }
}
