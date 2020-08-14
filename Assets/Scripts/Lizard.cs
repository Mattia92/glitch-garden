using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collisionObject = collision.gameObject;

        if(collisionObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(collisionObject);
        }
    }
}