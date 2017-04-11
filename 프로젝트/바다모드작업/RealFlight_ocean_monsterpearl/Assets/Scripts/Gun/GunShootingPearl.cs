using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootingPearl : MonoBehaviour {

    public GameObject pearl;
    public Transform shotPos;
    public float shootRate;

    private float nextShootRate;

    public GameObject udp;

    public bool shot; // udp 연결

    void Start()
    {
        shot = false;
    }

    void Update()
    {
        // 컨트롤러 연동하면 마우스 입력 버튼 bool 변수(컨트롤러에서 받아오는)로 변경
        if (Input.GetMouseButton(0) && Time.time > nextShootRate || shot == true && Time.time > nextShootRate)
        {
            ShootPearl();
            shot = false;
        }
    }

    void ShootPearl()
    {
        //
        nextShootRate = Time.time + shootRate;
        // 진주 발사 부분
        Instantiate(pearl, shotPos.position, pearl.transform.rotation);
    }
}
