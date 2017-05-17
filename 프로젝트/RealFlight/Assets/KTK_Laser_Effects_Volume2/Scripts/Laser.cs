
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    public float m_FireRange = 200f;
    public GameObject img;
    Image col;

    Vector3 trans;
	void Start()
	{
        col = img.GetComponent<Image>();
        col.color = Color.white;
	}
	
	void Update()
	{
		RaycastHit hit;


        trans = transform.position;
        trans.y -= 5f;
		if(Physics.Raycast(trans, -Vector3.up, out hit, m_FireRange))
		{
            //Debug.DrawLine(transform.position, hit.point, Color.red);
            //Debug.Log(hit.point);
            if (hit.collider.tag == "Eel" || hit.collider.tag == "Bat" || hit.collider.tag == "Shark")
            {
                Debug.Log("몬스터");
                col.color = Color.red;
            }

            else
            {
                col.color = Color.white;
            }

        }



       
	}
}
