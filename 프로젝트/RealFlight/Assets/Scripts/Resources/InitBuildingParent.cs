using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBuildingParent : MonoBehaviour
{
    public BuildAreaTrigger buildTrigger;
    public GameObject buildMarker;
    public Transform[] buildPos;
    public BuildManager bm;
    public ResourcesManager rm;

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
        if (bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding
            && buildTrigger.isVisibleBuilding_armor && buildTrigger.isVisibleBuilding_attk && buildTrigger.isVisibleBuilding_hp)
        {
            buildBaseBuilding();
        }
    }

    public void buildArmorBuilding()
    {
        GameObject building;
        GameObject particle;

        if (armorcount < 1)
        {
            building = Instantiate(Resources.Load("Prefabs/Buildings/Building_Armor"), buildPos[0].position, Quaternion.identity) as GameObject;
            particle = Instantiate(Resources.Load("Prefabs/magic_ring_blue"), buildPos[0].position, Quaternion.identity) as GameObject;
            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.05f, -35f, 0.1f);
            building.transform.localRotation = Quaternion.identity;

            particle.transform.parent = this.transform;
            particle.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));

            rm.armorCount = 0;
            this.GetComponent<AudioSource>().clip = Resources.Load("Audios/3. Build") as AudioClip;
            this.GetComponent<AudioSource>().Play();
        }
        armorcount++;
    }

    public void buildHpBuilding()
    {
        GameObject building;
        GameObject particle;

        if (hpcount < 1)
        {
            building = Instantiate(Resources.Load("Prefabs/Buildings/Building_HP"), buildPos[1].position, Quaternion.identity) as GameObject;
            particle = Instantiate(Resources.Load("Prefabs/magic_ring_blue"), buildPos[1].position, Quaternion.identity) as GameObject;
            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.07f, -35f, 0.1f);
            building.transform.localRotation = Quaternion.identity;

            particle.transform.parent = this.transform;
            particle.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));

            rm.hpCount = 0;
            this.GetComponent<AudioSource>().clip = Resources.Load("Audios/3. Build") as AudioClip;
            this.GetComponent<AudioSource>().Play();
        }
        hpcount++;
    }

    public void buildAttkBuilding()
    {
        GameObject building;
        GameObject particle;

        if (attkcount < 1)
        {
            building = Instantiate(Resources.Load("Prefabs/Buildings/Building_Attk"), buildPos[2].position, Quaternion.identity) as GameObject;
            particle = Instantiate(Resources.Load("Prefabs/magic_ring_blue"), buildPos[2].position, Quaternion.identity) as GameObject;
            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.12f, 0.14f, 35f);
            building.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));

            particle.transform.parent = this.transform;
            particle.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));

            rm.attkCount = 0;
            this.GetComponent<AudioSource>().clip = Resources.Load("Audios/3. Build") as AudioClip;
            this.GetComponent<AudioSource>().Play();
        }
        attkcount++;
    }

    void buildBaseBuilding()
    {
        GameObject building;
        GameObject particle;

        if (bCount < 1)
        {
            building = Instantiate(Resources.Load("Prefabs/Buildings/BaseBuilding"), buildPos[3].position, Quaternion.identity) as GameObject;
            particle = Instantiate(Resources.Load("Prefabs/magic_ring_yellow"), buildPos[3].position, Quaternion.identity) as GameObject;

            building.transform.parent = this.transform;
            building.transform.localScale = new Vector3(0.7f, 0.5f, 300f);
            building.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));

            particle.transform.parent = this.transform;
            particle.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));

            IsBuildBaseBuilding = true;
        }
        bCount++;
    }
}
