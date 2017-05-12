using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlMovement : MonoBehaviour {

    private Transform shotPos;
    private Rigidbody rb;

    public float power = 10f;





   
    // 속도 = 거리/시간 (오브젝트의 이동속도 : m/s
    // 거리 = 속도x시간(오브젝트가 1프레임에 이동할 거리)
    // 초속 * Time.deltaTime
    void Awake()
    {
       
        shotPos = GameObject.Find("Shotpos").transform;
        rb = GetComponent<Rigidbody>();

    }


	void Update () {
    
        rb.AddForce(shotPos.transform.forward * power);
	}

  
    
}
