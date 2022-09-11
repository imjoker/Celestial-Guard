using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject gameManager;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        Shoot ();
    }

    void MoveDown()
    {
        Vector2 newpos      = transform.position;
        newpos.y            = newpos.y - 0.003f;
        transform.position  = newpos;
    }

    void Shoot ()
    {

    }

    void OnTriggerEnter2D(Collider2D pCollidedGameObject)
    {
        if (pCollidedGameObject.tag == "Bullet") {

            gameManager.GetComponent<ScoreScript>().IncrementScore();
            Debug.Log("Score updated");
            Destroy (pCollidedGameObject.gameObject);
            Destroy (gameObject);


        }
    }
}
