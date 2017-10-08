﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EnemyUnitSpawn_Base : MonoBehaviour {

    public GameObject redMarker;
    public float spawnTime = 30f;

    private DefaultTrackableEventHandler rHandler;
    private const int enemyCount = 21;

    void Awake()
    {
        this.enabled = false;
    }

    // 건물 세개 다 지어지구 넥서스 지어지는것까지 체크 한 후에 이 스크립트 활성화
    void Start()
    {
        rHandler = redMarker.GetComponent<DefaultTrackableEventHandler>();
        InvokeRepeating("EnemyUnitSpawning", 0f, spawnTime);
    }

    void EnemyUnitSpawning()
    {
        GameObject unit;

        if (rHandler.IsRenderRed)
        {
            for (int i = 0; i < enemyCount; ++i)
            {
                unit = Instantiate(Resources.Load("Prefabs/EnemyUnit"), this.transform.position, Quaternion.identity) as GameObject;
                unit.transform.parent = this.transform;
                unit.transform.localScale = new Vector3(2f, 7f, 2f);
                unit.transform.localRotation = Quaternion.AngleAxis(180f, new Vector3(1f, 0f, 0f));
				unit.GetComponent<Unit> ().target = GameObject.FindWithTag ("BaseBuilding");
            }
        }
    }
}
