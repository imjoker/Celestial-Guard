using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemey : MonoBehaviour
{
    private float elapsed_time = 0f;
    public float desired_duration = 400f;
    private Vector2 playerpos;
    public GameObject gameManager;
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float percentage_complete;

        elapsed_time += Time.deltaTime;
        percentage_complete = elapsed_time / desired_duration;

        playerpos = GameObject.Find("Player").transform.position;

        transform.position = Vector2.Lerp(transform.position, playerpos, percentage_complete);
        
    }

    void OnTriggerEnter2D(Collider2D  pCollidedGameObject)
    {
        if (pCollidedGameObject.tag == "Bullet") 
        { 
            anim.SetTrigger("Die");
            Debug.Log("collide");
            Destroy(pCollidedGameObject.gameObject);

            gameManager.GetComponent<ScoreScript>().IncrementScore();
            Debug.Log("collide2");

            //Destroy (gameObject);
            //gameManager.GetComponent<ScoreScript>().IncrementScore();//I change the code follow "ScoreScript"
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
