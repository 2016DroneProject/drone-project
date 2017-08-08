using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitSpawn : MonoBehaviour {

    public float spawnTime = 30f;

    private const int enemyCount = 13;

	void Awake()
    {
        this.enabled = false;
    }

    void Start()
    {
        InvokeRepeating("EnemyUnitSpawning", 20f, spawnTime);
    }

    void EnemyUnitSpawning()
    {
        GameObject unit;

        for (int i = 0; i < enemyCount; ++i)
        {
            unit = Instantiate(Resources.Load("Prefabs/EnemyUnit"), this.transform.position, Quaternion.identity) as GameObject;
            unit.transform.parent = this.transform;
            unit.transform.localScale = new Vector3(2f, 7f, 2f);
            unit.transform.localRotation = Quaternion.AngleAxis(180f, new Vector3(1f, 0f, 0f));
        }
    }
}
