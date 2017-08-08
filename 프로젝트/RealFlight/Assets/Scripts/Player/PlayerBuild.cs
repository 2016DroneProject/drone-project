using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerBuild : MonoBehaviour {

    const int MAXROCK = 20;
    const int MAXLOG = 60;
    const int MAXBRICK = 30;

    public StartUIManager um;
    public ResourcesManager rm;
    public BuildManager bm;
    public State state;
    public enum State
    {
        startUI,
        build,
        control,
        NULL
    };

    private GameObject redmarker;
    private DefaultTrackableEventHandler rHandler;
    private AudioSource audio;

    void Awake()
    {
        redmarker = GameObject.FindWithTag("Build");
        rHandler = redmarker.GetComponent<DefaultTrackableEventHandler>();
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (rHandler.IsRenderRed)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AttackToBuild();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            um.SkipExplanation();
            um.count++;
        }
    }

    public void AttackToBuild()
    {
        audio.Play();
                if (rm.armorCount >= MAXROCK)
                {
                    Instantiate(Resources.Load("Prefabs/GameResources/rocks"), this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.armorBuild;
                    rm.armorCount = 0;

                }
                if (rm.attkCount >= MAXLOG)
                {
                    Instantiate(Resources.Load("Prefabs/GameResources/logs"), this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.attkBuild;
                    rm.attkCount = 0;
                }
                if (rm.hpCount >= MAXBRICK)
                {
                    Instantiate(Resources.Load("Prefabs/GameResources/bricks"), this.transform.position, Quaternion.identity);
                    bm.state = BuildManager.State.hpBuild;
                    rm.hpCount = 0;
                }
}


}
