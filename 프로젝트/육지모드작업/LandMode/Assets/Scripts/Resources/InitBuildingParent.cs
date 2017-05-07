using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBuildingParent : MonoBehaviour {

    public GameObject buildMarker;
    public GameObject[] buildings;
    public Transform[] buildPos;
    public BuildManager bm;
    public ResourcesManager rm;
    public BuildAreaTrigger buildTrigger;

    public bool IsBuildBaseBuilding;

    private int armorcount = 0;
    private int hpcount = 0;
    private int attkcount = 0;
    private int bCount = 0;

    void Start()
    {
        IsBuildBaseBuilding = false;
    }

    void Update()
    {
        if (bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding)
        {
            buildBaseBuilding();
        }
    }

    public void buildArmorBuilding()
    {
        GameObject building;

        if (armorcount < 1)
        {
            building = Instantiate(buildings[0], buildPos[0].position, Quaternion.identity);
            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.05f, -35f, 0.1f);
            building.transform.localRotation = Quaternion.identity;

            rm.armorCount = 0;
        }
        armorcount++;
    }

    public void buildHpBuilding()
    {
        GameObject building;

        if (hpcount < 1)
        {
            building = Instantiate(buildings[1], buildPos[1].position, Quaternion.identity);
            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.07f, -35f, 0.1f);
            building.transform.localRotation = Quaternion.identity;

            rm.hpCount = 0;
        }
        hpcount++;
    }

    public void buildAttkBuilding()
    {
        GameObject building;

        if (attkcount < 1)
        {
            building = Instantiate(buildings[2], buildPos[2].position, Quaternion.identity);
            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.2f, 0.3f, 35f);
            building.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));

            rm.attkCount = 0;
        }
        attkcount++;
    }

    void buildBaseBuilding()
    {
        GameObject building;

        if(bCount < 1)
        {
            building = Instantiate(buildings[3], buildPos[3].position, Quaternion.identity);

            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.7f, 0.5f, 300f);
            building.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            IsBuildBaseBuilding = true;
        }
        bCount++;
    }
}
