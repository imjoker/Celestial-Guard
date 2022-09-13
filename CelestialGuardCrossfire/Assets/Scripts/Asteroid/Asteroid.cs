using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject gameManager;
    private Rigidbody2D myBody;
    public int astrscore = 10;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
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
            gameManager.GetComponent<ScoreScript>().IncrementScore(astrscore);
        }
    }

    void OnCollisionEnter2D(Collision2D pCollidedGameObject)
    {
        if (pCollidedGameObject.gameObject.tag == "Bottom Wall")
        {
            Destroy(gameObject);
        }
    }
}
