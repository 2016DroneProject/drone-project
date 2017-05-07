using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShell : MonoBehaviour {

    public GameObject shell;


	// Use this for initialization
	void Start () {
        for(int i = 0; i < 60; i++)
        {
            makeShell();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void makeShell()
    {
        GameObject making;

        float x = Random.Range(-200.0f, 200.0f);
        float y = Random.Range(150f, 500.0f);
        float z = Random.Range(-200.0f, 200.0f);

        making = Instantiate(shell, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
        making.transform.parent = transform;
        making.transform.localScale = new Vector3(2f, 2f,2f);
        
    }
}
