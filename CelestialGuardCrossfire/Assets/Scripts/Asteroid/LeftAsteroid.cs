using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAsteroid : MonoBehaviour
{
    private Rigidbody2D myBody;
    public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft ();   
    }

    void MoveLeft()
    {
        Vector2 newpos = transform.position;
        newpos.x = newpos.x - 0.018f;
        transform.position = newpos;
    }

    void OnTriggerEnter2D(Collider2D pCollidedGameObject)
    {
        if (pCollidedGameObject.tag == "Bullet" || pCollidedGameObject.tag == "Wall")
        {
            if (pCollidedGameObject.tag == "Bullet")
                Destroy(pCollidedGameObject.gameObject);

            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D pCollidedGameObject)
    {
        if (pCollidedGameObject.gameObject.CompareTag ("Bullet") || pCollidedGameObject.gameObject.CompareTag("Wall"))
        {

            if (pCollidedGameObject.gameObject.CompareTag("Bullet"))
                Destroy(pCollidedGameObject.gameObject);

            Destroy(gameObject);
        }
    }
}
