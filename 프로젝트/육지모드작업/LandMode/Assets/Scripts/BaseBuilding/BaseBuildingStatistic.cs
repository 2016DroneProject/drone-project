using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingStatistic : MonoBehaviour {

    public int hp;
    public int armor;
    public int attk;

    void Start()
    {
        hp = 5000;
        armor = 0;
        attk = 0;
    }

}
