//======================================
/*
@autor ktk.kumamoto
@date 2015.3.13 create
@note Button_BackGroundOnOff
*/
//======================================


using UnityEngine;
using System.Collections;

public class Button_BackGroundOnOff : MonoBehaviour {
	
	private bool isChecked = true;
	public GameObject BG_Set;
	private string BackGround_State = "BackGround Display:ON";
	
	void OnGUI()
	{
		Rect rect1 = new Rect(400, 0, 200, 30);
		isChecked = GUI.Toggle(rect1, isChecked, BackGround_State);
		if (BG_Set != null){
			if (isChecked) {
				BackGround_State = "BackGround Display:ON";
				BG_Set.active = true;
			} else {
				BackGround_State = "BackGround Display:OFF";
				BG_Set.active = false;
			}
		}
	}
}