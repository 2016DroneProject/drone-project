using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerBuild : MonoBehaviour {

    const int MAXROCK = 20;
    const int MAXLOG = 60;
    const int MAXBRICK = 30;

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


    void Update()
    {

        if (rHandler.IsRenderRed)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (rm.armorCount >= MAXROCK)
                {
                    Instantiate(resources[0], this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.armorBuild;
                    rm.armorCount = 0;

                }
                if (rm.attkCount >= MAXLOG)
                {
                    Instantiate(resources[1], this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.attkBuild;
                    rm.attkCount = 0;
                }
                if (rm.hpCount >= MAXBRICK)
                {
                    Instantiate(resources[2], this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.hpBuild;
                    rm.hpCount = 0;
                }
            }

        }

    }


}
