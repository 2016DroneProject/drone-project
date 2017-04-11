//======================================
/*
@autor ktk.kumamoto
@date 2015.3.13 create
@note Button_EnemyEntryOnOff
*/
//======================================



using UnityEngine;
using System.Collections;


public class Button_EnemyEntryOnOff : MonoBehaviour {
	
	
	private bool isChecked = true;
	public GameObject EnemyEntry;
	private string EnemyEntry_State = "Enemy Entry:ON";
	
	
	void OnGUI()
	{
		Rect rect1 = new Rect(600, 0, 400, 30);
		isChecked = GUI.Toggle(rect1, isChecked, EnemyEntry_State);
		if (EnemyEntry != null){
			if (isChecked ) {
				EnemyEntry_State = "Enemy Entry:ON";
				EnemyEntry.active = true;
			} else {
				EnemyEntry_State = "Enemy Entry:OFF";
				EnemyEntry.active = false;
			}
		}
	}
}