using UnityEngine;
using System.Collections;

public class ShellMoving : MonoBehaviour {

    Vector3 originPos;
    int isTop;

    void Start()
    {
        originPos = transform.position;
        isTop = Random.Range(0, 2);
    }

    void Update() {
        transform.Translate(0,0.3f * Time.deltaTime, 0f);

        if (isTop == 1)
        {
            if(transform.position.y >= originPos.y + 0.25f)
            {
                isTop = 0;
            }
        }
        if (isTop == 0)
        {
            transform.Translate(0, -0.6f * Time.deltaTime, 0f);
            if (transform.position.y < originPos.y)
            {
                isTop = 1;
            }
        }
	}
}
