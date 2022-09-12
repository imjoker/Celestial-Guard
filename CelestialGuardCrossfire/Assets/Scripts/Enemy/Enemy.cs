using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject gameManager;
    public GameObject bullet;
    private bool canShoot = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(1f);

        Vector3 temp = transform.position;
        temp.y -= 1f;

        Instantiate(bullet, temp, Quaternion.identity);

        yield return new WaitForSeconds(0.3f);

        canShoot = true;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();

        if (canShoot)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if ((transform.position.y - player.transform.position.y) < 8f)
                StartCoroutine("Shoot");
        }
    }

    void MoveDown()
    {
        Vector2 newpos      = transform.position;
        newpos.y            = newpos.y - 0.003f;
        transform.position  = newpos;
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
