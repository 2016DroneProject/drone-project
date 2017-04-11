using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlAttack : MonoBehaviour {

    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bat" || other.tag == "Eel" || other.tag == "Shark")
        {
            MonsterHP hp = other.gameObject.GetComponent<MonsterHP>();
            hp.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
