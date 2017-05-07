using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BuildManager bm;
    public ArmorUnitSpawn armorUnitSpawn;
    public HpUnitSpawn hpUnitSpawn;
    public AttkUnitSpawn attkUnitSpawn;
	
	void Update () {

        if (bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding)
        {
            armorUnitSpawn.enabled = true;
            hpUnitSpawn.enabled = true;
            attkUnitSpawn.enabled = true;
        }

    }
}
