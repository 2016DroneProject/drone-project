using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartUIManager : MonoBehaviour {

    public PlayerBuild pb;
    public GameObject startUI;
    public GameObject baseBuildingStat;
    public GameObject enemyBuildingStat;
    public GameObject info;
    public GameObject renderCheckImage;
    public Text explanationText;
    public Text markerExplanation;
    public Text miniText;
    public Image blue;
    public Image yellow;
    public Image green;
    public Image red;
    public Image white;
    public TimeManager tm;

    public int count = 0;

    void Start()
    {
        info.SetActive(false);
        baseBuildingStat.SetActive(false);
        enemyBuildingStat.SetActive(false);
        
        blue.enabled = false;
        yellow.enabled = false;
        green.enabled = false;
        red.enabled = false;
        white.enabled = false;

        explanationText.text = "자원을 캐서 직접 지은 건물을 통해 아군 기지를\n방어하는 전략 게임 입니다.";
    }

    void Update()
    {

    }

    public void SkipExplanation()
    {
        switch (count) {
            case 1:
                {
                    blue.enabled = true;
                    explanationText.text = "";
                    markerExplanation.text = "BLUE 마커 자원 : 벽돌\n아군 기지의 체력을 올려주는 건물을 지을 수 있습니다.";
                } break;
            case 2:
                {
                    blue.enabled = false;
                    yellow.enabled = true;
                    markerExplanation.text = "YELLOW 마커 자원 : 돌\n아군 기지의 방어력을 올려주는 건물을 지을 수 있습니다.";
                }
                break;
            case 3:
                {
                    yellow.enabled = false;
                    green.enabled = true;
                    markerExplanation.text = "GREEN 마커 자원 : 나무\n아군 유닛의 공격력을 올려주는 건물을 지을 수 있습니다.";
                }
                break;
            case 4:
                {
                    green.enabled = false;
                    red.enabled = true;
                    markerExplanation.text = "RED 마커 : 아군 기지\n3가지 건물을 지을 수 있습니다.\n(넥서스 기본 체력 : 5000)";
                }
                break;
            case 5:
                {
                    red.enabled = false;
                    white.enabled = true;
                    markerExplanation.text = "WHITE 마커 : 적군 기지\n아군 유닛을 조종하여 공격해야 합니다.\n(RED마커-Shot 버튼으로 유닛 제어)";
                }
                break;
            case 6:
                {
                    white.enabled = false;
                    markerExplanation.text = "";
                    explanationText.text = "기지를 먼저 파괴하는 쪽이 승리합니다.\n제한 시간은 400초 입니다.";
                    miniText.text = "GameStart";
                    miniText.color = new Color(0.8f, 0.2f, 0.2f);
                } break;
            case 7:
                {
                    explanationText.text = "";
                    markerExplanation.text = "";
                    startUI.SetActive(false);
                    tm.enabled = true;

                    baseBuildingStat.SetActive(true);
                    enemyBuildingStat.SetActive(true);
                    info.SetActive(true);

                    this.GetComponent<AudioSource>().Play();
                    pb.state = PlayerBuild.State.build;

                }
                break;
            }
        
    }
}
