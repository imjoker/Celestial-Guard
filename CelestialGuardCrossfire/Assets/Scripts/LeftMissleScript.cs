using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMissleScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    private float speed = 5f;

    void Awake () {
        myBody = GetComponent<Rigidbody2D> ();
    }

    void Start () {
        myBody.velocity = new Vector2 (-speed, 0);
    }

    void OnTriggerEnter2D(Collider2D pCollidedGameObject)
    {
        if (pCollidedGameObject.tag != "Player")
            Destroy(gameObject);
    }
}
