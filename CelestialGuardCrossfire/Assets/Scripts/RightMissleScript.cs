using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMissleScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    private float speed = 7f;

    void Awake () {
        myBody = GetComponent<Rigidbody2D> ();
    }

    void Start () {
        myBody.velocity = new Vector2 (speed, 0);
    }

    void OnTriggerEnter2D(Collider2D pCollidedGameObject)
    {
        if (pCollidedGameObject.tag != "Player")
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D pCollidedGameObject)
    {
        if (pCollidedGameObject.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
