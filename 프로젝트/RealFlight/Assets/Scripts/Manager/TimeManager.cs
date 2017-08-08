using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public GameObject ResultScoreUI;
    public BuildManager bm;

    public Slider timerSlider;
    public Text timerText;

    private float timeLeft;

    void Awake()
    {
        this.enabled = false;
        ResultScoreUI.SetActive(false);
    }

    void Start()
    {
        timerSlider.value = 400;
        timeLeft = timerSlider.value;
    }

	void Update () {

		//if(bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding)
        {
            timeLeft -= Time.deltaTime;
            timerSlider.value = (int)timeLeft;
            timerText.text = timerSlider.value.ToString();

            if (timeLeft < 0)
            {
               
                GameOver();
            }

        }
    }

    public void GameOver()
    {
        ResultScoreUI.SetActive(true);
        Time.timeScale = 0;
    }
}
