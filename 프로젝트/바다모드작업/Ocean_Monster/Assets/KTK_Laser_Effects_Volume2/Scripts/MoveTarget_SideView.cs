//======================================
/*
@autor ktk.kumamoto
@date 2015.3.9 create
@note MouseClickPoint MoveTarget
*/
//======================================
using UnityEngine;
using System.Collections;

public class MoveTarget_SideView : MonoBehaviour {
	public Transform target;
	
	private void Update()
	{
		var pos = transform.position;
		pos.x = -0.5f;
		pos.y = 1.3f;
		if (Input.GetMouseButton(0))
		{
			Vector3 vec = Input.mousePosition;
			vec.z = 10f;
			
			target.position = GetComponent<Camera>().ScreenToWorldPoint(vec);

			target.transform.position = pos;
		}
	}
}