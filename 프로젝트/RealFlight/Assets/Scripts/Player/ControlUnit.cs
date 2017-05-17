using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ControlUnit : MonoBehaviour {

    public BuildManager bm;
    public bool canControl;

    private GameObject redmarker;
    private DefaultTrackableEventHandler rHandler;
    private PlayerBuild pb;

    void Awake()
    {
        redmarker = GameObject.FindWithTag("Build");
        rHandler = redmarker.GetComponent<DefaultTrackableEventHandler>();
        pb = GetComponent<PlayerBuild>();
    }

    void Update()
    {
        if (bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding)
        {
            if (rHandler.IsRenderRed)
            {
                pb.state = PlayerBuild.State.control;

                //if (Input.GetKeyDown(KeyCode.X))
                {
                    // 유닛이 플레이어 따라다니게
                    if (canControl || Input.GetKeyDown(KeyCode.X))
                    {
                        foreach (GameObject units in GameObject.FindObjectsOfType<GameObject>())
                        {
                            if (units.tag == "HpUnit" || units.tag == "ArmorUnit" || units.tag == "AttkUnit")
                            {
                                units.GetComponent<Unit>().ControlledByPlayer();
                            }
                        }
                    }
                }

            }
            else
            {
                pb.state = PlayerBuild.State.build;
            }
        }
    }

}
