using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnemyBuildingParent : MonoBehaviour {

    public GameObject enemyMarker;
    public Transform buildPos;
    public BuildManager bm;

    public bool IsBuildEnemyBuilding;

    private int bCount = 0;

    void Awake()
    {
        this.enabled = false;
    }

    void Start()
    {
        //IsBuildEnemyBuilding = false;
        buildEnemyBuilding();
    }

    //void Update()
    //{
    //    if (bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding)
    //    {
    //        buildEnemyBuilding();
    //    }
    //}

    void buildEnemyBuilding()
    {
        GameObject building;

        if (bCount < 1)
        {
            building = Instantiate(Resources.Load("Prefabs/Buildings/EnemyBuilding"), buildPos.position, Quaternion.identity) as GameObject;

            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.7f, 0.5f, 300f);
            building.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            IsBuildEnemyBuilding = true;
        }
        bCount++;
    }
}
