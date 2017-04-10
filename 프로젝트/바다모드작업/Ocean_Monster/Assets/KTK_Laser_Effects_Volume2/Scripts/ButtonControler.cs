//======================================
/*
@autor ktk.kumamoto
@date 2015.3.6 create
@note ButtonControler
*/
//======================================


using UnityEngine;
using System.Collections;

public class ButtonControler : MonoBehaviour {
	
	public GameObject[] EffectLaser_Set;
	private GameObject ShotEffect;
	public GameObject FPS_Camera;
	public GameObject TPS_Camera;
	public GameObject SideView_Camera;
	private int count_Effect;
	private int count_Effect2;
	
	private string CamLabel;
	private string EffLabel;

	//Light Slider
	public float hSliderValue = 1.15F;
	private Vector2 scrollViewVector = Vector2.zero;
	public Light Light; 
	
	
	
	void Awake(){
		for(int i = 0; i < EffectLaser_Set.Length; i++)
		{
			EffectLaser_Set[i] = Instantiate (EffectLaser_Set[i], this.transform.position, Quaternion.identity)as GameObject;
			EffectLaser_Set[i].name = EffectLaser_Set[i].name.Replace( "(Clone)", "" );
			EffectLaser_Set[i].transform.parent = transform;
		}
		count_Effect = 0;
		count_Effect2 = 0;
		CamLabel = "FPS_Camera";
		EffLabel = EffectLaser_Set[count_Effect2].name;
	}
	
	void Start(){
		for(int i = 0; i < EffectLaser_Set.Length; i++)
		{
			EffectLaser_Set[i].active = false;
		}
		ShotEffect = EffectLaser_Set[0];
	}
	
	void Update(){
		if (Input.GetMouseButtonDown(0)){
			
			ShotEffect.active = true;
		}
		if (Input.GetMouseButtonUp(0)) {
			ShotEffect.active = false;
		}

		if(Light != null){
			Light.GetComponent<Light>().intensity = hSliderValue;
		}


	}
	
	void OnGUI()
	{
		//Light Intencity Slider
		hSliderValue = GUI.HorizontalSlider(new Rect(25, 100, 160, 30), hSliderValue, 0.0F, 5.0F);
		GUI.Label(new Rect(200, 100,  200, 20), "Light Intensity: " + hSliderValue);



		GUI.Label(new Rect(200, 25, 150, 50), CamLabel);
		GUI.Label(new Rect(200, 60, 150, 50), EffLabel);
		GUI.Label(new Rect(200, 0, 250, 25), "Mouse Click laser firing!");
		
		//Camera Change
		if (GUI.Button (new Rect (25, 25, 160, 30), "Camera_Change"))
		{
			if(FPS_Camera.active == true){
				TPS_Camera.active = true;
				FPS_Camera.active = false;
				CamLabel = "TPS_Camera";
				
				
			}else if(TPS_Camera.active == true){
				SideView_Camera.active = true;
				TPS_Camera.active = false;
				CamLabel = "SideView_Camera";
			}else{
				FPS_Camera.active = true;
				SideView_Camera.active = false;
				CamLabel = "FPS_Camera";
			}
		}

		//Effect Change
		if (GUI.Button (new Rect (25, 60, 160, 30), "NextEffect"))
		{
			EffectLaser_Set[count_Effect2].active = false;
			
			count_Effect2 ++;
			
			if(count_Effect2 == EffectLaser_Set.Length){
				count_Effect2 = 0;
			}
			
			EffLabel = EffectLaser_Set[count_Effect2].name;
			
			ShotEffect = EffectLaser_Set[count_Effect2];
			
			
			
		}
		
	}
}