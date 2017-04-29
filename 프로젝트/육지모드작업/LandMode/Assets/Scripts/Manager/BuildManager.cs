using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public ResourcesManager rm;
    public BuildAreaTrigger buildTrigger;
    public GameObject[] buildings;

    public State state;
    public bool isEnemyStart;
    public enum State
    {
        attkBuild,
        armorBuild,
        hpBuild,
        NULL
    };

    private AimToBuild aim;
    private Vector3 posToBuild;
    private bool isArmorBuild;
    public int count = 0;
    
    void Awake()
    {
        aim = GameObject.Find("ARCamera").GetComponent<AimToBuild>();
    }

    void Start()
    {
        state = State.NULL;
        isEnemyStart = false;
    }

	void Update () {
        posToBuild = aim.buildPos;

        switch (state)
        {
            case State.armorBuild:
                {
                    if (buildTrigger.isVisibleBuilding)
                    {
                        buildArmorBuilding();
                        isEnemyStart = true;
                    }
                    break;
                }
            case State.hpBuild:
                {
                    if (buildTrigger.isVisibleBuilding)
                    {
                        buildHpBuilding();
                        isEnemyStart = true;
                    }
                    break;
                }
            case State.attkBuild:
                {
                    if (buildTrigger.isVisibleBuilding)
                    {
                        buildAttkBuilding();
                        isEnemyStart = true;
                    }
                    break;
                }
            case State.NULL:
                {
                    count = 0;
                    break;
                }
            // 어느 건물이든 하나가 지어지면 적군 건물도 같이 지어진다
        }
    }


    void buildArmorBuilding()
    {
        if (count < 1)
        {
            Instantiate(buildings[0], posToBuild, Quaternion.identity);
            rm.armorCount = 0;
        }
        count++;
        buildTrigger.isVisibleBuilding = false;
    }

    void buildHpBuilding()
    {
        if(count < 1)
        {
            Instantiate(buildings[1], posToBuild, Quaternion.identity);
            rm.hpCount = 0;
        }
        count++;
        buildTrigger.isVisibleBuilding = false;
    }

    void buildAttkBuilding()
    {
        if (count < 1)
        {
            Instantiate(buildings[2], posToBuild, Quaternion.identity);
            rm.attkCount = 0;
        }
        count++;
        buildTrigger.isVisibleBuilding = false;
    }
}
