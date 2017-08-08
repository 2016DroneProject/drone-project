using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Managetext2 : MonoBehaviour {

    string savestr;
    string m_strPath = "Assets/Resources/";
    GameObject stage;

    public Text[] Scores;
    public Text[] Names;

    Parse par;
    Order ord;

    int[] rank = new int[10];

    int[] sctest;
    string[] natest;

    public string myrank;

    int sortnum;

    void Start()
    {
        stage = GameObject.Find("UDP");
        par = stage.GetComponent<Parse>();
        ord = stage.GetComponent<Order>();

    }


    public void writing(int score)
    {

        WriteData(score.ToString());
        WriteData(",");
        WriteData(par.user.ToString("D4"));
        WriteData(",");
        WriteData("/");
        UnityEditor.AssetDatabase.Refresh();
    }

    public void reading()
    {
        Parser();

        string[] strs;

        strs = savestr.Split(',');

        ///위에까지 저장함

        /// 밑ㅇㅔ부터 점수 이름 따로 저장 시작 (지역변수)

        int score = 0;
        int name = 0;

        sctest = new int[(strs.Length - 1) / 2];
        natest = new string[(strs.Length - 1) / 2];

        for (int i = 1; i < strs.Length - 1; i += 2)
        {

            sctest[score] = System.Convert.ToInt32(strs[i - 1]);
            natest[name] = strs[i];
            score++;
            name++;
            //저장끝
        }

        sort();

        UnityEditor.AssetDatabase.Refresh();
    }

    void sort()
    {
        //정렬함수 


        System.Array.Sort(sctest, natest);


       

        int j = 0;

        if (sctest.Length < 10)
        {
            Debug.Log("leng" + sctest.Length);
            for (int i = sctest.Length - 1; i >= 0; i--)
            {

                Names[j].text = "User" + natest[i];
                Scores[j].text = sctest[i].ToString();

                int nauser;
                int.TryParse(natest[i], out nauser);

                if (sortnum < 1)
                {
                    if (nauser == par.user)
                    {
                        Debug.Log("same");
                        myrank = (sctest.Length - i).ToString();
                        sortnum++;
                    }
                    else
                    {
                        myrank = "X";
                    }
                }


                j++;
            }
        }
        else
        {
            for (int i = sctest.Length - 1; i >= sctest.Length - 10; i--)
            {


                Names[j].text = "User" + natest[i];
                Scores[j].text = sctest[i].ToString();

                int nauser;
                int.TryParse(natest[i], out nauser);

                if (sortnum < 1)
                {
                    if (nauser == par.user)
                    {
                        Debug.Log("same" + j);

                        myrank = (j + 1).ToString();
                        sortnum++;

                    }
                    else
                    {
                        myrank = "X";
                    }
                }

                j++;
            }
        }


    }

    void WriteData(string strData)

    {


        FileStream f = new FileStream(m_strPath + "Sea2.txt", FileMode.Append, FileAccess.Write);

        StreamWriter writer = new StreamWriter(f);

        writer.WriteLine(strData);

        writer.Close();

        UnityEditor.AssetDatabase.Refresh();

    }


    void Parser()

    {

        TextAsset data = Resources.Load("Sea2", typeof(TextAsset)) as TextAsset;

        StringReader sr = new StringReader(data.text);



        // 먼저 한줄을 읽는다. 



        string source = sr.ReadLine();

        string[] values;                // 쉼표로 구분된 데이터들을 저장할 배열 (values[0]이면 첫번째 데이터 )



        while (source != null)

        {


            values = source.Split('/');  // 쉼표로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.

            if (values.Length == 0)

            {

                sr.Close();

                return;

            }

            source = sr.ReadLine();    // 한줄 읽는다.


            for (int i = 0; i < values.Length; i++)
            {

                //Debug.Log("밸류" + values[i]);

                if (values[i] != "")
                {

                    savestr += values[i];

                }

            }
        }


        Debug.Log("savestr 파싱안" + savestr);


    }

}
