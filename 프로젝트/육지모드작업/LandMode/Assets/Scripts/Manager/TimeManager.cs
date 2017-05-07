using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public BuildManager bm;

    public Slider timerSlider;
    public Text timerText;

    private float timeLeft;
	
    void Start()
    {
        timerSlider.value = 240;
        timeLeft = timerSlider.value;
    }

	void Update () {

		if(bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding)
        {
            timeLeft -= Time.deltaTime;
            timerSlider.value = (int)timeLeft;
            timerText.text = timerSlider.value.ToString();

            if (timeLeft < 0)
            {
                //GameOver();
            }

        }
    }
}
