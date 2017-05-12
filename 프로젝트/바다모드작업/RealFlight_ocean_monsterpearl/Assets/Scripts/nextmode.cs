using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextmode : MonoBehaviour {

    int nextnum = 0;
    float timecount = 0;

    bool isScale = false;

    public GameObject[] mode;
    public GameObject[] mode_parti;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(nextnum > 0)
        {
            timecount += Time.deltaTime;
            

            if(nextnum > 0)
            {
                if (!isScale)
                {
                    Debug.Log(mode[nextnum - 1].transform.localScale.x);
                    mode[nextnum-1].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                    if (mode[nextnum - 1].transform.localScale.x > 1.2f)
                        isScale = true;
                }
                else if (isScale)
                {
                    mode[nextnum-1].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                    if (mode[nextnum - 1].transform.localScale.x < 0.7f)
                        isScale = false;
                }
            }

            if (timecount > 4)
            {
                SceneManager.LoadScene(nextnum);
            } 
        }
		
	}

    void nextstage(int num)
    {
        if(num == 1)
        {
            nextnum = 1;
            
        }

        if (num == 2)
        {
            nextnum = 2;
        }

        if (num == 3)
        {
            nextnum = 3;
        }

        mode_parti[num - 1].SetActive(true);
    }

    
}

