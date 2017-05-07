using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBox : MonoBehaviour {

    public GameObject[] boxes;
    public GameObject[] markers;

	// Use this for initialization
	void Start () {
        Random_make();
        EmptyBox();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Random_make()
    {
        int[] item_data = new int[] { 1, 2, 3, 4, 1, 2, 3, 4 }; // 배열 선언

        List<int> list = new List<int>(item_data); // 리스트 안에 위에 선언한 배열을 넣음

        for (int i = 0; i < item_data.Length; i++)
        {
            int tagetIndex = Random.Range(0, list.Count); // 랜덤함수로 인덱스 값을 얻음
            int a = list[tagetIndex]; // 리스트안에 그 인덱스값 번째에 해당하는 데이터를 뽑음
            list.Remove(list[tagetIndex]); // 그 데이터를 삭제
            item_data[i] = a;
        }

        for (int i = 0; i < item_data.Length; i++)
        {

            if(item_data[i] == 1)
            {
                Instancebox(0, i);


            }
            else if(item_data[i] == 2)
            {
                Instancebox(1, i);
            }

            else if (item_data[i] == 3)
            {
                Instancebox(2, i);
            }
            else if (item_data[i] == 4)
            {
                Instancebox(3, i);
            }

        }

    }

    void Instancebox(int num,int turn)
    {
        GameObject making;

        float x = Random.Range(-60.0f, 60.0f);
        float y = Random.Range(150f, 250.0f);
        float z = Random.Range(-60.0f, 60.0f);
       // int w = Random.Range(-180, 180);

        making = Instantiate(boxes[turn], new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
        making.transform.parent = markers[num].transform;
        //making.transform.Rotate(0, w, 0);
      
    }

    void EmptyBox()
    {
        for(int i=0;i< 6; i++)
        {
            Instancebox(0, 8);
            Instancebox(1, 8);
            Instancebox(2, 8);
            Instancebox(3, 8);
        }
        
    }

}
