using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    private float speed = 5f;

    void Awake () {
        myBody = GetComponent<Rigidbody2D> ();
    }

    void Start () {
        myBody.velocity = new Vector2 (0, speed);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Border") {
            Destroy(gameObject);
        }
    }
}
