using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerBuild : MonoBehaviour {

    public ResourcesManager rm;
    public BuildManager bm;
    public GameObject[] resources;

    private GameObject redmarker;
    private DefaultTrackableEventHandler rHandler;

    void Awake()
    {
        redmarker = GameObject.FindWithTag("Build");
        rHandler = redmarker.GetComponent<DefaultTrackableEventHandler>();
    }
	

	void Update () {
		
        if(rHandler.IsRenderRed)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if(rm.armorCount >= 20)
                {
                    Instantiate(resources[0],this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.armorBuild;
                }
                if(rm.attkCount >= 60)
                {
                    Instantiate(resources[1], this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.attkBuild;
                }
                if (rm.hpCount >= 30)
                {
                    Instantiate(resources[2], this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.hpBuild;
                }
            }

        }

	}

}
