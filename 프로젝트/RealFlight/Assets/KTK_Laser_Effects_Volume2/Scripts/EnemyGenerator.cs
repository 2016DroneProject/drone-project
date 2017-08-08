//======================================
/*
@autor ktk.kumamoto
@date 2015.3.10 create
@note EnemyGenerator
*/
//======================================

using UnityEngine;
using System.Collections;


public class EnemyGenerator : MonoBehaviour {
	public float waitTime = 1.0f;
	public float timer = 0.5f;
	public GameObject Enemy;
	
	public float AreaX = 1.0f;
	public float AreaY = 0.0f;
	public float AreaZ = 1.0f;
	
	void Start() {
		timer = waitTime;
	}
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0){
			float x = Random.Range( -AreaX , AreaX ) + transform.position.x;
			float y = Random.Range( -AreaY , AreaY ) + transform.position.y;
			float z = Random.Range( -AreaZ , AreaZ ) + transform.position.z;
			
			GameObject obj = (GameObject)Instantiate (Enemy, new Vector3( x , y, z ), Quaternion.identity);
			obj.transform.parent = transform;
			timer = waitTime;
		}
		
		
		
	}
}