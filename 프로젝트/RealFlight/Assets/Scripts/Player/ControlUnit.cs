using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ControlUnit : MonoBehaviour {

	public BuildManager bm;
	public ArrayList DropArrayList = new ArrayList();
	public GameObject[] SaveArray = new GameObject[12];
	public bool canControl = false;

	private GameObject redmarker;
	private GameObject whitemarker;
	private DefaultTrackableEventHandler rHandler;
	private DefaultTrackableEventHandler wHandler;
	private PlayerBuild pb;
	private int count = 0;
	private int dropCount = 0;

	void Awake()
	{
		redmarker = GameObject.FindWithTag("Build");
		whitemarker = GameObject.FindWithTag("EnemyArea");
		rHandler = redmarker.GetComponent<DefaultTrackableEventHandler>();
		wHandler = whitemarker.GetComponent<DefaultTrackableEventHandler>();
		pb = GetComponent<PlayerBuild>();
	}

	void Start()
	{
		canControl = false;
		count = 0;
		dropCount = 0;
	}

	void Update()
	{
		if (bm.isArmorBuilding && bm.isAttkBuilding && bm.isHpBuilding)
		{
			if (rHandler.IsRenderRed)
			{
				pb.state = PlayerBuild.State.control;

				//if (Input.GetKeyDown(KeyCode.X))
				{
					// 저장
					if (Input.GetKeyDown(KeyCode.X))
					{
                        dropCount = 0;
						foreach (GameObject units in GameObject.FindObjectsOfType<GameObject>())
						{
							if (units.tag == "AttkUnit" && count < 12)
							{
								SaveArray[count] = units;
								SaveArray[count].SetActive(false);

								//units.SetActive(false);
								count++;
							}
							else if (count >= 12)
							{
								count = 0;
							}
						}
					}
				}

			}
			else if (wHandler.IsRenderWhite)
			{
				pb.state = PlayerBuild.State.control;

				if (Input.GetKeyDown(KeyCode.X))
				{
					foreach (GameObject attkUnit in SaveArray)
					{
						if (SaveArray[dropCount] != null)
						{
							DropArrayList.Add(SaveArray[dropCount]);
							SaveArray[dropCount].GetComponent<Unit>().target = GameObject.FindWithTag("EnemyUnit");

							SaveArray[dropCount].SetActive(true);
                            SaveArray[dropCount].transform.parent = whitemarker.transform;
                            //SaveArray[dropCount].transform.localScale = new Vector3(2f, 7f, 2f);
                            SaveArray[dropCount].transform.localRotation = Quaternion.AngleAxis(180f, new Vector3(1f, 0f, 0f));

                            SaveArray[dropCount].GetComponent<SetAttkUnitMove>().enabled = true;

							SaveArray[dropCount] = null;

							dropCount++;
						}
					}
				}
			}
			else
			{
				pb.state = PlayerBuild.State.build;
			}
		}
	}

}
