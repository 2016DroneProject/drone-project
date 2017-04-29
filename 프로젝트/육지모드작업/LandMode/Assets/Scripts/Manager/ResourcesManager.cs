using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ResourcesManager : MonoBehaviour {

    public int armorCount;
    public int hpCount;
    public int attkCount;

    private GameObject yellowMarker;
    private GameObject blueMarker;
    private GameObject greenMarker;
    private DefaultTrackableEventHandler yHandler;
    private DefaultTrackableEventHandler bHandler;
    private DefaultTrackableEventHandler gHandler;

    void Awake() {
        yellowMarker = GameObject.FindWithTag("ArmorResources");
        blueMarker = GameObject.FindWithTag("HpResources");
        greenMarker = GameObject.FindWithTag("AttackResources");
        yHandler = yellowMarker.GetComponent<DefaultTrackableEventHandler>();
        bHandler = blueMarker.GetComponent<DefaultTrackableEventHandler>();
        gHandler = greenMarker.GetComponent<DefaultTrackableEventHandler>();
    }

    void Start()
    {
        armorCount = 0;
        hpCount = 0;
        attkCount = 0;
    }

    void Update() {

        GetResources();
    }

    void GetResources()
    {
        if (yHandler.IsRenderYellow)
        {
            yHandler.ytrackingTimer += Time.deltaTime;

            if (hpCount <= 0 && attkCount <= 0)
            {
                if (yHandler.ytrackingTimer >= 1.5f && yHandler.armorCapacity)
                {
                    armorCount++;

                    yHandler.ytrackingTimer = 0f;

                    if (armorCount >= 20)
                    {
                        yHandler.armorCapacity = false;
                    }
                }
            }
        }

        if (bHandler.IsRenderBlue)
        {

            bHandler.btrackingTimer += Time.deltaTime;

            if (armorCount <= 0 && attkCount <= 0)
            {
                if (bHandler.btrackingTimer >= 1f && bHandler.hpCapacity)
                {
                    hpCount++;

                    bHandler.btrackingTimer = 0f;

                    if (hpCount >= 30)
                    {
                        bHandler.hpCapacity = false;
                    }
                }
            }
        }

        if (gHandler.IsRenderGreen)
        {
            gHandler.gtrackingTimer += Time.deltaTime;

            if (armorCount <= 0 && armorCount <= 0)
            {
                if (gHandler.gtrackingTimer >= 0.5f && gHandler.attackCapacity)
                {
                    attkCount++;

                    gHandler.gtrackingTimer = 0f;

                    if (attkCount >= 60)
                    {
                        gHandler.attackCapacity = false;
                    }
                }
            }
        }
    }
}
