using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    //public ResourcesManager rm;
    public BuildAreaTrigger buildTrigger;
    public InitBuildingParent bp;
    public GameObject[] buildings;

    public State state;
    public int count = 0;
    public bool isAttkBuilding;
    public bool isArmorBuilding;
    public bool isHpBuilding;
    public enum State
    {
        attkBuild,
        armorBuild,
        hpBuild,
        NULL
    };

    private AimToBuild aim;
    private Vector3 posToBuild;

    void Start()
    {
        state = State.NULL;
        isArmorBuilding = false;
        isAttkBuilding = false;
        isHpBuilding = false;
    }

	void Update () {

        switch (state)
        {
            case State.armorBuild:
                {
                    if (buildTrigger.isVisibleBuilding)
                    {
                        count = 0;
                        bp.buildArmorBuilding();
                        isArmorBuilding = true;
                    }
                    break;
                }
            case State.hpBuild:
                {
                    if (buildTrigger.isVisibleBuilding)
                    {
                        count = 0;
                        bp.buildHpBuilding();
                        isHpBuilding = true;
                    }
                    break;
                }
            case State.attkBuild:
                {
                    if (buildTrigger.isVisibleBuilding)
                    {
                        count = 0;
                        bp.buildAttkBuilding();
                        isAttkBuilding = true;
                    }
                    break;
                }
            case State.NULL:
                {
                    count = 0;
                    break;
                }
            // 어느 건물이든 하나가 지어지면 적군 건물도 같이 지어진다
            // 세건물 다 지어지면 타이머 시작 및 아군 넥서스 생성
        }
    }


    //void buildArmorBuilding()
    //{
    //    if (count < 1)
    //    {
    //        Instantiate(buildings[0], posToBuild, Quaternion.identity);
    //        rm.armorCount = 0;
    //    }
    //    count++;
    //    buildTrigger.isVisibleBuilding = false;
    //}

    //void buildHpBuilding()
    //{
    //    if(count < 1)
    //    {
    //        Instantiate(buildings[1], posToBuild, Quaternion.identity);
    //        rm.hpCount = 0;
    //    }
    //    count++;
    //    buildTrigger.isVisibleBuilding = false;
    //}

    //void buildAttkBuilding()
    //{
    //    if (count < 1)
    //    {
    //        Instantiate(buildings[2], posToBuild, Quaternion.identity);
    //        rm.attkCount = 0;
    //    }
    //    count++;
    //    buildTrigger.isVisibleBuilding = false;
    //}
}
