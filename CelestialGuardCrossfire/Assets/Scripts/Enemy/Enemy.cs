using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }

    void MoveDown()
    {
        Vector2 newpos      = transform.position;
        newpos.y            = newpos.y - 0.003f;
        transform.position  = newpos;
    }   

    void OnCollisionEnter2D(Collision2D pCollidedGameObject)
    {
        if (pCollidedGameObject.gameObject.CompareTag ("Bullet")) { 
            
            Destroy (pCollidedGameObject.gameObject);
            Destroy (gameObject);

            gameManager.GetComponent<ScoreScript>().IncrementScore();
        }
    }
}
