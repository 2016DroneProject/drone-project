using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2Manager : MonoBehaviour {

    public StageNum stage;

    int item_num = 0;

    public Material[] box_material;
    public Material[] colored;

    float max_time1;
    float max_time2;

    float timer1;
    float timer2;
    float m_fAlpha;

    int scope = 5;
    int high = 3;
    int bomb = 15;
    int paint = 6;
    GameObject bill;
    GameObject gem;
    GameObject gold;
    GameObject goldcoin;
    GameObject moneybag;
    GameObject pack;
    GameObject potion;
    GameObject silvercoin;



    //Find Shine 오브젝트 찾아서 setactive 

    // Use this for initialization
    void Start () {
        
        m_fAlpha = 1f;
        for (int i = 0; i < box_material.Length; i++)
            box_material[i].color = new Color(box_material[i].color.r, box_material[i].color.b, box_material[i].color.g, m_fAlpha);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.C) || stage.item == 1)
        {
            Debug.Log("머테리얼");
            stage.item = 0;
            if(scope > 0 )
                Useflu();

        }

        if (Input.GetKeyUp(KeyCode.G) || stage.item == 2)
        {
            Debug.Log("머테리얼");
            stage.item = 0;
            if (high > 0)
                UseHigh();

        }

        if (timer1 < max_time1)
        {
            Debug.Log("타이머" + timer1);
            timer1 += Time.deltaTime;
            m_fAlpha = 0.4f;

            for(int i = 0; i< box_material.Length;i++)
                box_material[i].color = new Color(box_material[i].color.r, box_material[i].color.b, box_material[i].color.g, m_fAlpha);


            if (timer1 >= max_time1)
            {
                max_time1 = 0;
                timer1 = 0;

                m_fAlpha = 1f;
                for (int i = 0; i < box_material.Length; i++)
                    box_material[i].color = new Color(box_material[i].color.r, box_material[i].color.b, box_material[i].color.g, m_fAlpha);
            }
        }
		
	}

    void Useflu()
    {
        scope--;
        max_time1 = 10f;
        timer1 = 0;
    }

    void UseHigh()
    {
        high--;
        max_time2 = 10f;
        timer2 = 0;
    }

    void FindParticle()
    {
        bill = GameObject.FindGameObjectWithTag("Bill");
        gem = GameObject.FindGameObjectWithTag("Gem");

    }
}
