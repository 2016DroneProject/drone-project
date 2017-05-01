using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour {


    int num;

    bool start = false;

    bool is_opening = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.O))
        {
            if(is_opening == false)
                start = true;
        }
		
        if(start == true)
        {
            Debug.Log(transform.rotation.x);
            if (transform.rotation.x > -0.8)
            {
                this.transform.Rotate(-30 * Time.deltaTime, 0, 0);
                is_opening = true;

                
            }

            else
            {
                start = false;
                is_opening = false;
            }

        }
	}

    IEnumerator Open()
    {
        Debug.Log("들어옴");

        if (transform.rotation.x > -90)
            this.transform.Rotate(-1 * Time.deltaTime, 0, 0);
        else
            StopCoroutine("Open");

        num++;
  
        yield return null;
    }
}
