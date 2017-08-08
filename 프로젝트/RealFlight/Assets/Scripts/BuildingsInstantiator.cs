using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BuildingsInstantiator : MonoBehaviour, ITrackableEventHandler
{
    public GameObject[] buildings;
    public ResourcesManager rm;
    public AimToBuild aim;

    private TrackableBehaviour mTrackableBehaviour;
    private Vector3 pos;
    private int count = 0;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        count = 0;
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    void Update()
    {
        pos = aim.buildPos;
    }


    public void buildArmorBuilding()
    {
        if (count < 1)
        {
            GameObject building;
            building = Instantiate(buildings[0], aim.buildPos, Quaternion.identity);

            rm.armorCount = 0;
        }
        count++;

    }

    public void buildHpBuilding()
    {
        if (count < 1)
        {
            GameObject building;
            building = Instantiate(buildings[1], aim.buildPos, Quaternion.identity);

            rm.hpCount = 0;
        }
        count++;

    }

    public void buildAttkBuilding()
    {
        if (count < 1)
        {
            GameObject building;
            building = Instantiate(buildings[2], aim.buildPos, Quaternion.identity);

            rm.attkCount = 0;
        }
        count++;
    }


    public void OnTrackableStateChanged(
              TrackableBehaviour.Status previousStatus,
              TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            OnTrackingFound();
        }
    }

    private void OnTrackingFound()
    {
        //if (myModelPrefab != null)
        //{
        //    Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;

        //    myModelTrf.parent = mTrackableBehaviour.transform;
        //    myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
        //    myModelTrf.localRotation = Quaternion.identity;
        //    myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);

        //    myModelTrf.gameObject.active = true;
        //}
    }
}
