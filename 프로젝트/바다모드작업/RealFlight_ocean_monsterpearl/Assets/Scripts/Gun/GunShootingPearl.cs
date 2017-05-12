using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootingPearl : MonoBehaviour {

    public GameObject pearl;
    public GameObject shell;
    public Transform shotPos;
    public float shootRate;




    public bool shot; // udp 연결

    public GameObject stage;
    StageNum stage_num;

    AudioSource ac;

    void Start()
    {
        shot = false;

        stage_num = stage.GetComponent<StageNum>();
        ac = GetComponent<AudioSource>();
    }

    void Update()
    {

        // 컨트롤러 연동하면 마우스 입력 버튼 bool 변수(컨트롤러에서 받아오는)로 변경 Time.time > nextShootRate 
        if ((stage_num.num == 3 || stage_num.num == 4) && ((Input.GetMouseButtonDown(0)) ||( shot == true)))
        {

            if (stage_num.pearl_num > 0)
            {
                ShootPearl();
                shot = false;
            }
        }

        else if (stage_num.num == 2 && ((Input.GetMouseButtonDown(0) || shot == true )))
        {
            if (stage_num.shell_num >= 3)
            {
                ShootShell();
                shot = false;
            }

        }
    }

    void ShootPearl()
    {
        //
        ac.Play();

        // 진주 발사 부분

        stage_num.pearl_num--;
        Instantiate(pearl, shotPos.position, pearl.transform.rotation);
    }

    void ShootShell()
    {
        ac.Play();

        // 조개 발사 부분
        
        Instantiate(shell, shotPos.position, pearl.transform.rotation);
    }

    void Shotboolean()
    {
        shot = true;
    }
}
