using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : MonoBehaviour {

    public GameObject bat;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            makeBat();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void makeBat()
    {
        GameObject making;

        float x = Random.Range(-150.0f,150.0f);
        float y = Random.Range(70.0f, 350.0f);
        float z = Random.Range(-100.0f, 100.0f);
        int w = Random.Range(-180, 180);

        //Debug.Log(w);
        making = Instantiate(bat, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
        making.transform.parent = transform;
        making.transform.Rotate(0, w, 0);


    }
}
