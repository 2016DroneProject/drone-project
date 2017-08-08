using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuildingStatistic : MonoBehaviour {

    public bool isDestroy;
    public int hp;
    public int currentHp;
    public int armor;

	private TimeManager tm;
    private GameObject stage;
    private Order score;

    void Start()
    {
        hp = 5000;
        armor = 0;
        currentHp = hp;

        stage = GameObject.Find("UDP");
        score = stage.GetComponent<Order>();
		tm = GameObject.Find ("Manager/GameManager").GetComponent<TimeManager>();
    }

    void Update()
    {
        if(currentHp <= 0)
        {
            isDestroy = true;
            score.Land_Score += 1000;

			tm.GameOver();
        }
    }

    public void TakeDamaged(int amount)
    {
        currentHp -= amount;
    }
		
}
