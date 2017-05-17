//======================================
/*
@autor ktk.kumamoto
@date 2015.3.9 create
@note MouseClickPoint MoveTarget
*/
//======================================
using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour {
	public Transform target;
	
	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 vec = Input.mousePosition;
			vec.z = 10f;
			
			target.position = GetComponent<Camera>().ScreenToWorldPoint(vec);
		}
	}
}