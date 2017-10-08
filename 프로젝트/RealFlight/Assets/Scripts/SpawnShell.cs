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
        //Debug.Log("조개다시");
        GameObject making;

        float x = Random.Range(-150.0f, 150.0f);
        float y = Random.Range(135f, 450.0f);
        float z = Random.Range(-150.0f, 150.0f);

        making = Instantiate(shell, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
        making.transform.parent = transform;
        making.transform.localScale = new Vector3(2f, 2f,2f);
        
    }
}
