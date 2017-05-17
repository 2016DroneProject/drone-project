using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputData : MonoBehaviour {

    public PlayerBuild pb;
    public ControlUnit cu;
    public StartUIManager um;

    //public Text heightText;

    private GameObject UDP;
    private Order udporder;

	void Start () {
        UDP = GameObject.Find("UDP");
        udporder = UDP.GetComponent<Order>();
    }

    void Update() {

        //heightText.text = "HEIGHT\n" + udporder.rcvPack.altitude + "m";

        if (udporder.rcvPack.bAttack == true)
        {
            switch (pb.state) {
                case PlayerBuild.State.startUI:
                    {
                        um.SkipExplanation();
                        um.count++;
                        udporder.rcvPack.bAttack = false;
                        break;
                    }
                case PlayerBuild.State.build:
                    {
                        pb.AttackToBuild();
                        udporder.rcvPack.bAttack = false;
                        break;
                    }
                case PlayerBuild.State.control:
                    {
                        cu.canControl = true;
                        udporder.rcvPack.bAttack = false;
                        break;
                    }
                }
            }
	   }

    
}
