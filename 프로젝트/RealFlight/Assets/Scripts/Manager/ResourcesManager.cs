using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ResourcesManager : MonoBehaviour {

    public Slider resourceSlider;
    public Text[] resourceText;
    public GameObject[] resourceImage;
    
    public int armorCount;
    public int hpCount;
    public int attkCount;

    private GameObject stage;
    private Order score;
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

        stage = GameObject.Find("UDP");
        score = stage.GetComponent<Order>();

        resourceSlider.value = 0;
        resourceSlider.gameObject.SetActive(false);
        resourceText[0].gameObject.SetActive(false);
        resourceText[1].gameObject.SetActive(false);
        resourceText[2].gameObject.SetActive(false);
        resourceImage[0].gameObject.SetActive(false);
        resourceImage[1].gameObject.SetActive(false);
        resourceImage[2].gameObject.SetActive(false);
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
                if (yHandler.ytrackingTimer >= 0.75f && yHandler.armorCapacity)
                {
                    resourceSlider.gameObject.SetActive(true);
                    resourceText[0].gameObject.SetActive(true);
                    resourceImage[0].gameObject.SetActive(true);
                    resourceSlider.maxValue = 20;

                    armorCount++;
                    score.Land_Score += 40;

                    resourceSlider.value = armorCount;
                    resourceText[0].text = armorCount.ToString() + " / 20";
                    yHandler.ytrackingTimer = 0f;

                    if (armorCount >= 20)
                    {
                        yHandler.armorCapacity = false;
                        resourceSlider.GetComponent<AudioSource>().Stop();
                    }

                }
            }
        }

        if (bHandler.IsRenderBlue)
        {
            bHandler.btrackingTimer += Time.deltaTime;

            if (armorCount <= 0 && attkCount <= 0)
            {
                if (bHandler.btrackingTimer >= 0.5f && bHandler.hpCapacity)
                {
                    resourceSlider.gameObject.SetActive(true);
                    resourceText[1].gameObject.SetActive(true);
                    resourceImage[1].gameObject.SetActive(true);
                    resourceSlider.maxValue = 30;

                    hpCount++;
                    score.Land_Score += 25;

                    resourceSlider.value = hpCount;
                    resourceText[1].text = hpCount.ToString() + " / 30";
                    bHandler.btrackingTimer = 0f;

                    if (hpCount >= 30)
                    {
                        bHandler.hpCapacity = false;
                        resourceSlider.GetComponent<AudioSource>().Stop();
                    }
                }
            }
        }

        if (gHandler.IsRenderGreen)
        {
            gHandler.gtrackingTimer += Time.deltaTime;

            if (armorCount <= 0 && armorCount <= 0)
            {
                if (gHandler.gtrackingTimer >= 0.25f && gHandler.attackCapacity && yHandler.armorCapacity && bHandler.hpCapacity )
                {
                    resourceSlider.gameObject.SetActive(true);
                    resourceText[2].gameObject.SetActive(true);
                    resourceImage[2].gameObject.SetActive(true);
                    resourceSlider.maxValue = 60;

                    attkCount++;
                    score.Land_Score += 10;

                    resourceSlider.value = attkCount;
                    resourceText[2].text = attkCount.ToString() + " / 60";
                    gHandler.gtrackingTimer = 0f;

                    if (attkCount >= 60)
                    {
                        gHandler.attackCapacity = false;
                        resourceSlider.GetComponent<AudioSource>().Stop();
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
            resourceImage[0].gameObject.SetActive(false);
            resourceImage[1].gameObject.SetActive(false);
            resourceImage[2].gameObject.SetActive(false);
        }
    }

}
