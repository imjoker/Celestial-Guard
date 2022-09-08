using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemey : MonoBehaviour
{
    private float elapsed_time = 0f;
    public float desired_duration = 400f;
    private Vector2 playerpos;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
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

    void OnTriggerEnter2D(Collider2D pCollidedGameObject)
    {
        if (pCollidedGameObject.gameObject.CompareTag("Bullet"))
        {

            Destroy(pCollidedGameObject.gameObject);
            Destroy(gameObject);

            gameManager.GetComponent<ScoreScript>().IncrementScore();
        }
        else if (pCollidedGameObject.gameObject.CompareTag("Player"))
        {
            elapsed_time = 0;
        }
    }
}
