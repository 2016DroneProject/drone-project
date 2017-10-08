using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBuildingStatManager : MonoBehaviour {

	public Slider enemyHpSlider;
	public Text attkPercentText;
	public Text armorPercentText;

	public InitBuildingParent bp;
	public int armorPercemt;
	public int attkPercent;

	private EnemyBuildingStatistic ebst;

	void Update()
	{
		if(bp.IsBuildBaseBuilding)
		{
			ebst = GameObject.FindWithTag("EnemyBuilding").GetComponent<EnemyBuildingStatistic>();
			enemyHpSlider.maxValue = ebst.hp;
			enemyHpSlider.value = ebst.currentHp;

			StatCheck ();
		}
	}

	void StatCheck()
	{
		armorPercemt = 10;
		attkPercentText.text = "10%";

		armorPercentText.text = "20%";
	}
}

