using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class monster2_num : MonoBehaviour {

    public int n_eel;
    public int n_shark;

    public GameObject eel_text;
    Text eelText;

    public GameObject shark_text;
    Text sharkText;

    void Start () {
        eelText = eel_text.GetComponent<Text>();
        sharkText = shark_text.GetComponent<Text>();


    }
	
	void Update () {
        eelText.text = n_eel + "/" + "1";
        sharkText.text = n_shark + "/" + "1";	
	}
}
