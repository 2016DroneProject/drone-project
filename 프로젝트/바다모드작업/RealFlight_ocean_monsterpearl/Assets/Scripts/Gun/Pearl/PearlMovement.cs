using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlMovement : MonoBehaviour {

    private Transform shotPos;
    private Rigidbody rb;
    private float speed = 1.5f;
    private float power = 10f;
    private float movement;

    // 속도 = 거리/시간 (오브젝트의 이동속도 : m/s
    // 거리 = 속도x시간(오브젝트가 1프레임에 이동할 거리)
    // 초속 * Time.deltaTime
    void Awake()
    {
        shotPos = GameObject.Find("ARCamera/RightGun/RayGun_EW1/Barrel/Shotpos").transform;
        rb = GetComponent<Rigidbody>();
    }


	void Update () {
        movement = speed * Time.deltaTime;  // 매 프레임마다 이동 거리
        rb.AddForce(shotPos.transform.forward * power);
	}
}
