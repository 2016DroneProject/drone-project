using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour {

    int[] mission_data = new int[6];

    // 0 - Bill
    // 1 - Gem
    // 2 - Gold
    // 3 - GoldCoin
    // 4 - MoneyBag
    // 5 - Pack
    // 6 - Potion
    // 7 - SilverCoin
    // 완료 Clear

    public GameObject mission1;
    public GameObject mission2;
    Image mission1_img;
    Image mission2_img;

    public Sprite[] spr;

    public int stage_num;

    float stage_timer = 0;

    string[] str_mission = new string[6];

    public string now_mission1;
    public string now_mission2;
    public GameObject clear1;
    public GameObject clear2;

    Stage2 st;

    Text mission_text;

    public GameObject end;
    public GameObject timer;

    // Use this for initialization    
    void Start () {

        mission_text = GameObject.Find("Mission").GetComponent<Text>();
        st = GameObject.Find("StageNum").GetComponent<Stage2>();

        AssignMission();
        inttostr();

        stage_num = 1;

        now_mission1 = null;
        now_mission2 = null;
        mission1_img = mission1.GetComponent<Image>();
        mission2_img = mission2.GetComponent<Image>();

        mission1_img.sprite = spr[mission_data[0]];
        mission2_img.sprite = spr[mission_data[1]];

        now_mission1 = str_mission[0];
        now_mission2 = str_mission[1];
    }
	
	// Update is called once per frame
	void Update () {

        stage_timer += Time.deltaTime;

        mission_text.text = "Mission " + stage_num;

        if (now_mission1 == "Clear")
            clear1.SetActive(true);

        else if (now_mission2 == "Clear")
            clear2.SetActive(true);
       
            
		
	}

    void AssignMission()
    {
        int[] item_data = new int[] { 0,1, 2, 3, 4, 5, 6, 7 }; // 배열 선언


        List<int> list = new List<int>(item_data); // 리스트 안에 위에 선언한 배열을 넣음


        for (int i = 0; i < mission_data.Length; i++)
        {
            int tagetIndex = Random.Range(0, list.Count); // 랜덤함수로 인덱스 값을 얻음
            int a = list[tagetIndex]; // 리스트안에 그 인덱스값 번째에 해당하는 데이터를 뽑음
            list.Remove(list[tagetIndex]); // 그 데이터를 삭제
            mission_data[i] = a;
        }

        for (int i = 0; i < mission_data.Length; i++)
        {
            //Debug.Log(mission_data[i]);
        }
    }

    public void nextstage()
    {
        if (stage_timer < 40)
        {
            st.score += 750;
        }
        else if (stage_timer >= 40 && stage_timer < 80)
        {
            st.score += 450;
        }

        else if (stage_timer >= 80 && stage_timer < 100)
        {
            st.score += 200;
        }

        else
        {
            st.score += 50;
        }

        stage_timer = 0;

        
        stage_num++;

        clear1.SetActive(false);
        clear2.SetActive(false);
        now_mission1 = null;
        now_mission2 = null;

        if (stage_num == 2)
        {
            mission1_img.sprite = spr[mission_data[2]];
            mission2_img.sprite = spr[mission_data[3]];
            now_mission1 = str_mission[2];
            now_mission2 = str_mission[3];
        }

        if (stage_num == 3)
        {
            mission1_img.sprite = spr[mission_data[4]];
            mission2_img.sprite = spr[mission_data[5]];
            now_mission1 = str_mission[4];
            now_mission2 = str_mission[5];
        }

        if (stage_num == 4)
        {
            
            stage_num = 3;
            clear1.SetActive(true);
            clear2.SetActive(true);
			end.SetActive(true);
            Destroy(timer.gameObject,1f);

        }
    }
    void inttostr()
    {
        for (int i = 0; i < mission_data.Length; i++)
        {
            if (mission_data[i] == 0)
                str_mission[i] = "Bill";
            else if(mission_data[i] == 1)
                str_mission[i] = "Gem";
            else if (mission_data[i] == 2)
                str_mission[i] = "Gold";
            else if (mission_data[i] == 3)
                str_mission[i] = "GoldCoin";
            else if (mission_data[i] == 4)
                str_mission[i] = "MoneyBag";
            else if (mission_data[i] == 5)
                str_mission[i] = "Pack";
            else if (mission_data[i] == 6)
                str_mission[i] = "Potion";
            else if (mission_data[i] == 7)
                str_mission[i] = "SilverCoin";
        }
    }

    
}
