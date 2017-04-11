//======================================
/*
@autor ktk.kumamoto
@date 2015.3.13 create
@note Enemy_Hp
*/
//======================================


using UnityEngine;
using System.Collections;

public class Enemy_Hp : MonoBehaviour {
	
	public int life=50;
	public GameObject BurstEffect;
	
	public void ApplyDamage(int damage){
		life-=damage;
		print("LifePoint= " + life);
		if (life < 0){
			Instantiate (BurstEffect, this.transform.position ,Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}