using UnityEngine;
using System.Collections;

public class ShellMoving : MonoBehaviour {

    Vector3 originPos;
    int isTop;

    public float speed;

    public GameObject mesh;

    void Start()
    {
        originPos = transform.position;
        isTop = Random.Range(0, 2);

    }

    void Update() {
        
        if (isTop == 1)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            if (transform.position.z >= originPos.z + 20f)
            {
                isTop = 0;
                mesh.transform.Rotate(0, 0, -180);
            }
        }

        if (isTop == 0)
        {
            transform.Translate(0, 0, -1 * speed * Time.deltaTime);
           
            if (transform.position.z < originPos.z)
            {
                isTop = 1;
                mesh.transform.Rotate(0, 0, 180);
            }
        }
	}
}
