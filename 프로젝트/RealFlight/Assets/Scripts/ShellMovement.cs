using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMovement : MonoBehaviour {
    private Transform shotPos;
    private Rigidbody rb;

    public float power = 10f;



    GameObject stage;
    StageNum stage_num;
    int num;

    AudioSource ac;

    // 속도 = 거리/시간 (오브젝트의 이동속도 : m/s
    // 거리 = 속도x시간(오브젝트가 1프레임에 이동할 거리)
    // 초속 * Time.deltaTime
    void Awake()
    {
        stage = GameObject.Find("StageNum");
        shotPos = GameObject.Find("ARCamera/RightGun/RayGun_EW1/Barrel/Shotpos").transform;
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AudioSource>();
    }


    void Update()
    {
        // 매 프레임마다 이동 거리
        rb.AddForce(shotPos.transform.forward * power);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MakePearl")
        {
            if (num == 0)
            {
                ac.Play();
                StageNum st = stage.GetComponent<StageNum>();
                st.pearl_num += st.shell_num / 2;
                st.shell_num = st.shell_num % 2;
                num++;
                Destroy(this.gameObject, 2f);
            }

        }
    }
}
