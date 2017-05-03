﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ResourcesManager : MonoBehaviour {

    public Slider resourceSlider;
    public Text[] resourceText;

    public int armorCount;
    public int hpCount;
    public int attkCount;

    private GameObject yellowMarker;
    private GameObject blueMarker;
    private GameObject greenMarker;
    private DefaultTrackableEventHandler yHandler;
    private DefaultTrackableEventHandler bHandler;
    private DefaultTrackableEventHandler gHandler;

    void Awake()
    {
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

        
        resourceSlider.value = 0;
        resourceSlider.gameObject.SetActive(false);
        resourceText[0].gameObject.SetActive(false);
        resourceText[1].gameObject.SetActive(false);
        resourceText[2].gameObject.SetActive(false);
    }

    void Update()
    {
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
                    resourceSlider.gameObject.SetActive(true);
                    resourceText[0].gameObject.SetActive(true);
                    resourceSlider.maxValue = 20;

                    armorCount++;
                    resourceSlider.value = armorCount;
                    resourceText[0].text = armorCount.ToString() + " / 20";
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
                    resourceSlider.gameObject.SetActive(true);
                    resourceText[1].gameObject.SetActive(true);
                    resourceSlider.maxValue = 30;

                    hpCount++;
                    resourceSlider.value = hpCount;
                    resourceText[1].text = hpCount.ToString() + " / 30";
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
                    resourceSlider.gameObject.SetActive(true);
                    resourceText[2].gameObject.SetActive(true);
                    resourceSlider.maxValue = 60;

                    attkCount++;
                    resourceSlider.value = attkCount;
                    resourceText[2].text = attkCount.ToString() + " / 60";
                    gHandler.gtrackingTimer = 0f;

                    if (attkCount >= 60)
                    {
                        gHandler.attackCapacity = false;
                    }
                }

            }
        }

        if (armorCount <= 0 && !yHandler.armorCapacity)
        {
            yHandler.armorCapacity = true;

            resourceSlider.value = armorCount;
            resourceText[0].text = armorCount.ToString() + " / 20";
        }

        if (hpCount <= 0 && !bHandler.hpCapacity)
        {
            bHandler.hpCapacity = true;

            resourceSlider.value = hpCount;
            resourceText[1].text = hpCount.ToString() + " / 60";
        }

        if (attkCount <= 0 && !gHandler.attackCapacity)
        {
            gHandler.attackCapacity = true;

            resourceSlider.value = attkCount;
            resourceText[2].text = attkCount.ToString() + " / 60";
        }

        if(resourceSlider.value <= resourceSlider.minValue)
        {
            resourceSlider.gameObject.SetActive(false);
            resourceText[0].gameObject.SetActive(false);
            resourceText[1].gameObject.SetActive(false);
            resourceText[2].gameObject.SetActive(false);
        }
    }

}
