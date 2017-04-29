using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public ResourcesManager rm;
    public Text armorTxt;
    public Text hpTxt;
    public Text attkTxt;

	void Update () {
        armorTxt.text = "돌: " + rm.armorCount.ToString();
        attkTxt.text = "나무: " + rm.attkCount.ToString();
        hpTxt.text = "벽돌: " + rm.hpCount.ToString();
	}
}
