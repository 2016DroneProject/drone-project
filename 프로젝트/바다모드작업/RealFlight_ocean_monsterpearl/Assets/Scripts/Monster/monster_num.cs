using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class monster_num : MonoBehaviour {

    public int num;

    public GameObject num_text;
    Text text;

    public GameObject right;
    public GameObject left;

    //RightPlayerShooting RS;
    //LeftPlayerShooting LS;

    LineRenderer line_r;
    LineRenderer line_l;
    Color32 green_start;
    Color32 green_end;
    Color32 purple_start;
    Color32 purple_end;

    void Start () {
        text = num_text.GetComponent<Text>();
        //RS = right.GetComponent<RightPlayerShooting>();
        //LS = left.GetComponent<LeftPlayerShooting>();
        //line_r = right.GetComponent<LineRenderer>();
        //line_l = left.GetComponent<LineRenderer>();
        green_start = new Color32(113,255,173,255);
        green_end = new Color32(5, 184, 21,255);
        purple_start = new Color32(15,76,255,255);
        purple_end = new Color32(30,0,255,255);
	}
	
	void Update () {
        text.text = num + "/" + "1";

        if(num >= 3 && num < 6)
        {
            //line_r.SetColors(green_start,green_end);
            //line_l.SetColors(green_start, green_end);


        }
        else if (num >= 6 )
        {
            //line_r.SetColors(purple_start, purple_end);
            //line_l.SetColors(purple_start, purple_end);
        }

    }
}
