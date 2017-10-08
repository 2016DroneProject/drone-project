using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text infoText;
    public BuildManager bm;
    public BuildAreaTrigger trigger;
    public ArmorUnitSpawn armorUnitSpawn;
    public HpUnitSpawn hpUnitSpawn;
    public AttkUnitSpawn attkUnitSpawn;
    public EnemyUnitSpawn_Base enemyUnitSpawn_Base;
    public EnemyUnitSpawn enemyUnitSpawn;
    public InitEnemyBuildingParent initEnemyBuilding;
	
	void Update () {

        if (bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding
            && trigger.isVisibleBuilding_armor && trigger.isVisibleBuilding_attk && trigger.isVisibleBuilding_hp)
        {
            infoText.text = "Shot 버튼으로\n유닛을 조종하세요!";
            armorUnitSpawn.enabled = true;
            hpUnitSpawn.enabled = true;
            attkUnitSpawn.enabled = true;
            enemyUnitSpawn.enabled = true;
            enemyUnitSpawn_Base.enabled = true;
            initEnemyBuilding.enabled = true;
        }

    }
}
