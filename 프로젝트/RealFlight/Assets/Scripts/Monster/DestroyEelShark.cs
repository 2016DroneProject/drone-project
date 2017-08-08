using UnityEngine;
using System.Collections;

public class DestroyEelShark : MonoBehaviour {

    GameObject EelNum;
    GameObject SharkNum;

    monster2_num eelNum;
    monster2_num sharkNum;

    void Awake()
    {
        EelNum = GameObject.Find("Monster2_Num");
        eelNum = EelNum.GetComponent<monster2_num>();
        SharkNum = GameObject.Find("Monster2_Num");
        sharkNum = SharkNum.GetComponent<monster2_num>();
    }

    void Update() {
        if (eelNum.n_eel >= 1 && sharkNum.n_shark >= 1)
        {
            Destroy(gameObject, 1f);
        }
    }
}
