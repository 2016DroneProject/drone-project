using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public float destroyTime;

    private float timer;

	void Update () {
        timer += Time.deltaTime;

        if (timer >= destroyTime)
            Destroy(this.gameObject);
	}
}
