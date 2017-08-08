using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBuildingStatManager : MonoBehaviour {

    public Slider hpSlider;
    public Slider enemyHpSlider;
    public Text attkPercentText;
    public Text armorPercentText;

    public InitBuildingParent bp;
    public int armorPercent;
    public int attkPercent;

    private BaseBuildingStatistic bbst;
    private EnemyBuildingStatistic ebst;

    void Update()
    {
        StatCheck();

        if(bp.IsBuildBaseBuilding)
        {
            bbst = GameObject.FindWithTag("BaseBuilding").GetComponent<BaseBuildingStatistic>();
            ebst = GameObject.FindWithTag("EnemyBuilding").GetComponent<EnemyBuildingStatistic>();
            hpSlider.maxValue = bbst.hp;
            hpSlider.value = bbst.currentHp;

            enemyHpSlider.maxValue = ebst.currentHp;
            enemyHpSlider.value = ebst.currentHp;
        }
    }

    void StatCheck()
    {
        foreach (GameObject buildings in GameObject.FindObjectsOfType<GameObject>())
        {
            if (buildings.tag == "AttkBuilding")
            {
                armorPercent = 10;
                attkPercentText.text = "10%";
            }
            else if (buildings.tag == "ArmorBuilding")
            {
                armorPercentText.text = "20%";
            }
        }
    }

}
