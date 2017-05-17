using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuildingStatistic : MonoBehaviour {

    public bool isDestroy;
    public int hp;
    public int currentHp;
    public int armor;

    void Start()
    {
        hp = 5000;
        armor = 0;
        currentHp = hp;
    }

    void Update()
    {
        if(currentHp <= 0)
        {
            isDestroy = true;
        }
    }

    public void TakeDamaged(int amount)
    {
        currentHp -= amount;
    }
}
