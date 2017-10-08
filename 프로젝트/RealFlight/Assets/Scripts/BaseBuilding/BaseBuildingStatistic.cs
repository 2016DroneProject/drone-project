using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingStatistic : MonoBehaviour {

    public bool isDestroy;
    public int hp;
    public int currentHp;
    public int armor;

	private TimeManager tm;
    private BuildManager bm;
    private BaseBuildingStatManager bbsm;
    private int hCount = 0;

    void Awake()
    {
        bm = GameObject.Find("Manager/BuildManager").GetComponent<BuildManager>();
        bbsm = GameObject.Find("Manager/StatUIManager").GetComponent<BaseBuildingStatManager>();
		tm = GameObject.Find ("Manager/GameManager").GetComponent<TimeManager>();
    }

    void Start()
    {
        hp = 5000;
        currentHp = hp;
        armor = 0;
    }

    void Update()
    {
        //if (hCount <= 0)
        //{
        //    if (bm.isHpBuilding)
        //    {
        //        currentHp += 500;
        //        hCount++;
        //    }
        //}

		if (currentHp <= 0) {
			tm.GameOver();
		}
    }

    public void TakeDamaged(int amount)
    {
        currentHp = currentHp - (int)(amount - (amount * (bbsm.armorPercent * 0.1)));
    }
		

}
