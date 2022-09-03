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

    void FixedUpdate () {
        myBody.velocity = new Vector2 (speed, 0);
    }
}
