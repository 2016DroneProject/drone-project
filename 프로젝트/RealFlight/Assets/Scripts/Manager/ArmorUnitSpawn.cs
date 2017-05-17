﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ArmorUnitSpawn : MonoBehaviour {

    public GameObject redMarker;
    public float spawnTime = 30f;

    private DefaultTrackableEventHandler rHandler;
    private const int armorCount = 4;

    void Awake()
    {
        this.enabled = false;
    }

    // 건물 세개 다 지어지구 넥서스 지어지는것까지 체크 한 후에 이 스크립트 활성화
    void Start()
    {
        rHandler = redMarker.GetComponent<DefaultTrackableEventHandler>();
        InvokeRepeating("ArmorUnitSpawning", 0f, spawnTime);
    }

    void ArmorUnitSpawning()
    {
        GameObject unit;

        if (rHandler.IsRenderRed)
        {
            for (int i = 0; i < armorCount; ++i)
            {
                unit = Instantiate(Resources.Load("Prefabs/ArmorUnit"), this.transform.position, Quaternion.identity) as GameObject;
                unit.transform.parent = this.transform;
                unit.transform.localScale = new Vector3(2f, 7f, 2f);
                unit.transform.localRotation = Quaternion.AngleAxis(180f, new Vector3(1f, 0f, 0f));
            }
        }
    }
}
