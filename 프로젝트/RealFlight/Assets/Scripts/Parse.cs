using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class Parse : MonoBehaviour {
    public string savestr;


    // Use this for initialization

    string m_strPath = "Assets/Resources/";

    public int user;
    int next_user;

    void Start()
    {
    
       
    }



    public void edittext()
    {
        TextAsset data = Resources.Load("Users", typeof(TextAsset)) as TextAsset;

        StringReader sr = new StringReader(data.text);

        string source = sr.ReadLine();

        int.TryParse(source, out user);
        //위에까지 유저 번호 저장

        //다음 유저 번호가 +1 되게 
        next_user = user + 1;

        Debug.Log(next_user);
        //현재 유저번호 다음 유저번호로 ㄷㅐ체
        source = Regex.Replace(source, user.ToString(), next_user.ToString());

        sr.Close();

        string strPath = "Assets/Resources/Users.txt";

        StreamWriter writer = new StreamWriter(strPath);

        writer.Write(source);

        writer.Close();

        UnityEditor.AssetDatabase.Refresh();

    }

}
