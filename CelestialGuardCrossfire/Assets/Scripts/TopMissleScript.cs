using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMissleScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    private float speed = 7f;

    void Awake () {
        myBody = GetComponent<Rigidbody2D> ();
    }

    void Start () {
        myBody.velocity = new Vector2 (0, speed);
    }

    void OnTriggerEnter2D(Collider2D  pCollidedGameObject)
    {
        if (pCollidedGameObject.tag != "Player")
        {
            
            Destroy(gameObject);
        }
    }
}
