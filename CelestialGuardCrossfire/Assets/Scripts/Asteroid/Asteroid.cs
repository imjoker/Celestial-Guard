using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown ();   
    }

    void MoveDown()
    {
        Vector2 newpos = transform.position;
        newpos.y = newpos.y - 0.018f;
        transform.position = newpos;
    }

    void OnTriggerEnter2D(Collider2D pCollidedGameObject)
    {
        if (pCollidedGameObject.tag == "Bullet")
        {
            Destroy(pCollidedGameObject.gameObject);
            Destroy(gameObject);
        }
    }
}
