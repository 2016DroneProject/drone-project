using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnUnitManager : MonoBehaviour {

    public Transform HpBuildingPos;
    public Transform ArmorBuildingPos;
    public Transform AttkBuildingPos;

    public float spawnTime = 30f;

    private const int hpCount = 7;
    private const int armorCount = 5;
    private const int attkCount = 15;

    void Awake()
    {
        this.enabled = false;
    }

    // 건물 세개 다 지어지구 넥서스 지어지는것까지 체크 한 후에 이 스크립트 활성화
    void Start()
    {
        InvokeRepeating("HPUnitSpawn", 0f, spawnTime);
        InvokeRepeating("ArmorUnitSpawn", 0f, spawnTime);
        InvokeRepeating("AttkUnitSpawn", 0f, spawnTime);
    }

    void HpUnitSpawn()
    {
            for (int i = 0; i < hpCount; ++i)
            {
                Instantiate(Resources.Load("Prefabs/HPUnit"), HpBuildingPos.position, Quaternion.identity);
            }

    }

    void ArmorUnitSpawn()
    {

            for (int i = 0; i < armorCount; ++i)
            {
                Instantiate(Resources.Load("Prefabs/ArmorUnit"), ArmorBuildingPos.position, Quaternion.identity);
            }

    }

    void AttkUnitSpawn()
    {

            for (int i = 0; i < attkCount; ++i)
            {
                Instantiate(Resources.Load("Prefabs/AttkUnit"), AttkBuildingPos.position, Quaternion.identity);
            }
    }
}
