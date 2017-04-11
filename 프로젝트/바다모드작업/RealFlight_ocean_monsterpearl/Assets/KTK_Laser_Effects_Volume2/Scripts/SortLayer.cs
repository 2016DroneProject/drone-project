using UnityEngine;
using System.Collections;

public class SortLayer : MonoBehaviour {

	public int sortLayer = 1;
	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().sortingOrder =  sortLayer;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
