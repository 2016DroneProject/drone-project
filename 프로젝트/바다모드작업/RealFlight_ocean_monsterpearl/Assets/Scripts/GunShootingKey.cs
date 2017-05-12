using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootingKey : MonoBehaviour {

    public GameObject stage;


    public Transform shotPos;
    public float shootRate;

    AudioSource ac;
    public bool shot;

    private float nextShootRate;
    public GameObject key;
    
    void Start()
    {
        shot = false;


        ac = GetComponent<AudioSource>();
    }

    void Update()
    {

        // 컨트롤러 연동하면 마우스 입력 버튼 bool 변수(컨트롤러에서 받아오는)로 변경 Time.time > nextShootRate
        if ((Input.GetMouseButtonDown(0) || (shot == true)) && Time.time > nextShootRate)
        {

            ShootKey();
            shot = false;
            
        }

       
    }

    void ShootKey()
    {
        //
        ac.Play();
        nextShootRate = Time.time + shootRate;
        // 진주 발사 부분

       
        Instantiate(key, shotPos.position, key.transform.rotation);
    }

    void Shotboolean()
    {
        shot = true;
    }
}
