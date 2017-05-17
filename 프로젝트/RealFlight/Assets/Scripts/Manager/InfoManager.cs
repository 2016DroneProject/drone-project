using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class InfoManager : MonoBehaviour {

    public GameObject renderCheckImage;

    private GameObject redMarker;
    private DefaultTrackableEventHandler rHandler;

    void Awake()
    {
        redMarker = GameObject.FindWithTag("Build");
        rHandler = redMarker.GetComponent<DefaultTrackableEventHandler>();

        renderCheckImage.SetActive(false);
    }

    void Update()
    {
        if (rHandler.IsRenderRed)
        {
            renderCheckImage.SetActive(true);
        }
        else
        {
            renderCheckImage.SetActive(false);
        }
    }
}
