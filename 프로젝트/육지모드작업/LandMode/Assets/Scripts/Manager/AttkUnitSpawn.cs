using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttkUnitSpawn : MonoBehaviour {

    public float spawnTime = 30f;

    private const int attkCount = 5;

    void Awake()
    {
        this.enabled = false;
    }

    // 건물 세개 다 지어지구 넥서스 지어지는것까지 체크 한 후에 이 스크립트 활성화
    void Start()
    {
        InvokeRepeating("AttkUnitSpawning", 0f, spawnTime);
    }

    void AttkUnitSpawning()
    {
        GameObject unit;

        for (int i = 0; i < attkCount; ++i)
        {
            unit = Instantiate(Resources.Load("Prefabs/AttkUnit"), this.transform.position, Quaternion.identity) as GameObject;
            unit.transform.parent = this.transform;
            unit.transform.localScale = new Vector3(2f, 2f, 2f);
            unit.transform.localRotation = Quaternion.identity;
        }
    }
}
