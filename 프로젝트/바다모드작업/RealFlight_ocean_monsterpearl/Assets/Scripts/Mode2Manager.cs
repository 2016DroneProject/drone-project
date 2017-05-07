using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mode2Manager : MonoBehaviour {


    int item_num = 0;

    public Material[] box_material;

    float max_time1;
    float max_time2;

    float timer1;
    float timer2;
    float m_fAlpha;

    int scope = 5;
    Text scope_txt;

    int high = 3;
    Text high_txt;
    int bomb = 15;
    Text bomb_txt;
    int paint = 6;
    Text paint_txt;

    GameObject bill;
    GameObject gem;
    GameObject gold;
    GameObject goldcoin;
    GameObject moneybag;
    GameObject pack;
    GameObject potion;
    GameObject silvercoin;


    GameObject UDP;
    Order udporder;

    GameObject[] highlights = new GameObject[32];

    Image high_img;
    Image scope_img;

    Transform shotPos;

    public GameObject bomb_obj;

    //Find Shine 오브젝트 찾아서 setactive 

    // Use this for initialization
    void Start () {

        UDP = GameObject.Find("UDP");
        udporder = UDP.GetComponent<Order>();

        shotPos = GameObject.Find("Shotpos").GetComponent<Transform>();

        bomb_txt = GameObject.Find("Bomb_Num").GetComponent<Text>();
        high_txt = GameObject.Find("High_Num").GetComponent<Text>();
        paint_txt = GameObject.Find("Paint_Num").GetComponent<Text>();
        scope_txt = GameObject.Find("Scope_Num").GetComponent<Text>();

        high_img = GameObject.Find("Highlight").GetComponent<Image>();
        scope_img = GameObject.Find("Scope").GetComponent<Image>();

        SetHighLight();
        
        m_fAlpha = 1f;
        for (int i = 0; i < box_material.Length; i++)
            box_material[i].color = new Color(box_material[i].color.r, box_material[i].color.b, box_material[i].color.g, m_fAlpha);
    }
	
	// Update is called once per frame
	void Update () {

        bomb_txt.text = bomb + "";
        high_txt.text = high + "";
        paint_txt.text = paint + "";
        scope_txt.text = scope + "";

        if (Input.GetKeyUp(KeyCode.C) || udporder.rcvPack.KindItem == 3)
        {
            Debug.Log("머테리얼");
            udporder.rcvPack.KindItem = 0;
            if(scope > 0 )
                Useflu();

        }

        if (Input.GetKeyUp(KeyCode.G) || udporder.rcvPack.KindItem == 2)
        {
            Debug.Log("하이라이트");
            udporder.rcvPack.KindItem = 0;
            if (high > 0)
                UseHigh();

        }

        if (Input.GetKeyUp(KeyCode.B) || udporder.rcvPack.KindItem == 1)
        {
            Debug.Log("폭탄");
            udporder.rcvPack.KindItem = 0;
            if (bomb > 0)
                UseBomb();

        }

        if (timer1 < max_time1)
        {
            //Debug.Log("타이머" + timer1);
            timer1 += Time.deltaTime;
            m_fAlpha = 0.4f;

            for(int i = 0; i< box_material.Length;i++)
                box_material[i].color = new Color(box_material[i].color.r, box_material[i].color.b, box_material[i].color.g, m_fAlpha);


            scope_img.fillAmount = (max_time1 - timer1) / max_time1;
            if (timer1 >= max_time1)
            {
                max_time1 = 0;
                timer1 = 0;
                scope_img.fillAmount = 1;
                m_fAlpha = 1f;
                for (int i = 0; i < box_material.Length; i++)
                    box_material[i].color = new Color(box_material[i].color.r, box_material[i].color.b, box_material[i].color.g, m_fAlpha);
            }
        }


        if (timer2 < max_time2)
        {
            //Debug.Log("타이머2" + timer2);
            timer2 += Time.deltaTime;

            high_img.fillAmount = (max_time2 - timer2) / max_time2;

            if (timer2 >= max_time2)
            {
                high_img.fillAmount = 1;
                for (int i = 0; i < 32; i++)
                {
                    if (highlights[i] != null)
                        highlights[i].SendMessage("disactiveshine");
                }
                max_time2 = 0;
                timer2 = 0;
               


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

        for(int i = 0; i < 32; i++)
        {
            if (highlights[i] != null)
                highlights[i].SendMessage("activeshine");
        }
    }

    void SetHighLight()
    {
      
        int i = 0;
        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name == "pasted__pasted__obj_Low_lid")
            {

                highlights[i] = gameObj;
                i++;
            }
        }
    }

    void UseBomb()
    {
        bomb--;
        Instantiate(bomb_obj, shotPos.position, bomb_obj.transform.rotation);
    }


}
