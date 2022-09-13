using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class playerScript : MonoBehaviour
{
    public enum PowerUps { INACTIVE, DOUBLE_PLAYER };

    [SerializeField]
    private GameObject top_rocket;
    [SerializeField]
    private GameObject bottom_rocket;
    [SerializeField]
    private GameObject left_rocket;
    [SerializeField]
    private GameObject right_rocket;

    [SerializeField]
    private AudioClip shootSound;

    [SerializeField]
    private int lives = 3;

    private Vector2 playerBegin;


    private float[] speed = { 8f, 31f };
    private float[] maxVelocity = { 4f, 8f };

    private Rigidbody2D myBody;
    private Animator anim;

    private bool canShoot;

    public GameObject bottomBorder;
    public GameObject topBorder;

    private float timer;
    private PowerUps currPowerUp;

    private GameObject doublePlayer;

    public GameObject[] WaveSystems;

    public bool isActualPlayer = true;

    public TextMeshProUGUI livesText;

    void Awake () {
        InitializeVariables ();
    }

    void Update () {
        Shoot ();

        PowerUpHandler();
    }

    void FixedUpdate () {
        PlayerWalk ();
    }

    void PowerUpHandler ()
    {
        if (currPowerUp != PowerUps.INACTIVE)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            MakeCurrentPowerUpInactive();
        }
    }

    void MakeCurrentPowerUpInactive ()
    {
        if (currPowerUp == PowerUps.DOUBLE_PLAYER)
            Destroy(doublePlayer);

        currPowerUp = PowerUps.INACTIVE;
    }

    void Shoot() {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canShoot)
            {
                StartCoroutine(Shootrocket());
            }
        }
    }

    IEnumerator Shootrocket()
    {
        //anim.Play ("Shoot");
        Vector3 temp = transform.position;
        temp.y += 1f;
        Instantiate (top_rocket, temp, Quaternion.identity);

        temp = transform.position;
        temp.x += 1f;
        Instantiate(right_rocket, temp, Quaternion.identity);

        temp = transform.position;
        temp.x -= 1f;

        Instantiate(left_rocket, temp, Quaternion.identity);

        temp = transform.position;
        temp.y -= 1f;

        Instantiate(bottom_rocket, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint(shootSound, transform.position);

        yield return new WaitForSeconds (0.3f);

        canShoot = true;

    }

    IEnumerator ShootTheRight_rocket()
    {
        //anim.Play ("Shoot");
        Vector3 temp = transform.position;
        temp.x += 1f;

        Instantiate(right_rocket, temp, Quaternion.identity);

       // AudioSource.PlayClipAtPoint(shootSound, transform.position); 
        //SoundManagerScripts.PlaySound ("celestialguard_shoot");
        yield return new WaitForSeconds(0.3f);

        //anim.SetBool ("Shoot", false);

        canShoot = true;

    }

    IEnumerator ShootTheBottom_rocket()
    {
        //anim.Play ("Shoot");
        Vector3 temp = transform.position;
        temp.y -= 1f;

        Instantiate(bottom_rocket, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint(shootSound, transform.position); // !!!!

        yield return new WaitForSeconds(0.3f);

        //anim.SetBool ("Shoot", false);

        canShoot = true;

    }

    IEnumerator ShootTheLeft_rocket()
    {
        //anim.Play ("Shoot");
        Vector3 temp = transform.position;
        temp.x -= 1f;

        Instantiate(left_rocket, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint(shootSound, transform.position); // !!!!

        yield return new WaitForSeconds(0.3f);

        //anim.SetBool ("Shoot", false);

        canShoot = true;

    }

    void InitializeVariables()
    {
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        canShoot = true;
        playerBegin = new Vector2(0f, -4.2f);
        lives -= 1;
        timer = 0;
        currPowerUp = PowerUps.INACTIVE;
    }

    // Update is called once per frame
    void PlayerWalk()
    {
        var force = 0f;
        var force1 = 0f;
        var velocity = Mathf.Abs (myBody.velocity.x);

        
        float h = Input.GetAxis ("Horizontal");//You can change the key diraction code
        float A = Input.GetAxis ("Vertical");

        bool isShiftDown = Input.GetKey(KeyCode.LeftShift);

        if(h > 0)
        {
        // moving right
        if(velocity < maxVelocity[Convert.ToInt32(isShiftDown)])
            force = speed[Convert.ToInt32(isShiftDown)];

            Vector3 scale = transform.localScale;
        //scale.x = 1;
        transform.localScale = scale;

        //anim.SetBool("Walk, true);
        }

        else if(h < 0)
        {
            //moving left
            if(velocity < maxVelocity[Convert.ToInt32(isShiftDown)])
                force = -speed[Convert.ToInt32(isShiftDown)];

            Vector3 scale = transform.localScale;
            //scale.x = -1;
            transform.localScale = scale;

            //anim.SetBool("Walk, true);
        }

        
        if(A > 0)
        {
        // moving up
        if(velocity < maxVelocity[Convert.ToInt32(isShiftDown)])
            force1 = speed[Convert.ToInt32(isShiftDown)];

            Vector3 scale = transform.localScale;
        //scale.y = 1;
        transform.localScale = scale;

            //anim.SetBool("Walk, true);

            if (isShiftDown)
                force1 -= 6f;
        }
        else if(A < 0)
        {
            //moving down
            if(velocity < maxVelocity[Convert.ToInt32(isShiftDown)])
                force1 = -speed[Convert.ToInt32(isShiftDown)];

            Vector3 scale = transform.localScale;
            //scale.y = 1;
            transform.localScale = scale;

            //anim.SetBool("Walk, true);

            if (isShiftDown)
                force1 += 6f;
        }

        myBody.AddForce (new Vector2(force, 0));
        myBody.AddForce (new Vector2(0, force1));
    }

    void OnCollisionEnter2D(Collision2D pCollidedGameObject)
    {
        if (GetComponent<playerScript>().isActualPlayer == false)
        {
            if (pCollidedGameObject.gameObject.CompareTag("Enemy") || pCollidedGameObject.gameObject.tag == "Wall")
                Destroy(gameObject);
            return;
        }
            

        if (pCollidedGameObject.gameObject.CompareTag("Enemy") || pCollidedGameObject.gameObject.tag == "Wall")
        {
            
            if (lives > 0)
            {
                anim.Play ("player_hurt");
                Respawn();
            }
            else
            {
                anim.Play ("player_die");
                SceneManager.LoadScene("UI");

            }
        }
    }

    void OnTriggerEnter2D(Collider2D pCollidedGameObject)
    {
        if (GetComponent<playerScript>().isActualPlayer == false)
        {
            if (pCollidedGameObject.gameObject.CompareTag("Enemy") || pCollidedGameObject.gameObject.CompareTag ("Wall"))
                Destroy(gameObject);

            return;
        }

        if (pCollidedGameObject.gameObject.CompareTag("Enemy") || pCollidedGameObject.gameObject.CompareTag("Wall"))
        {
            if (lives > 0)
            {
                Respawn();
            }
            else
            {
                anim.Play("player_die");
                SceneManager.LoadScene("UI");
            }
        }
        else if (pCollidedGameObject.gameObject.CompareTag("Double-Player"))
        {
                Vector2 vec;

            vec = new Vector2 (transform.position.x + 2, transform.position.y);

            doublePlayer = Instantiate(gameObject, vec, transform.rotation);
            timer = 10f;
            currPowerUp = PowerUps.DOUBLE_PLAYER;

            doublePlayer.GetComponent<playerScript> ().isActualPlayer = false;
        }
    }

    void Respawn ()
    {
        livesText.text = "Lives: " + lives.ToString();

        lives -= 1;
        transform.position = playerBegin;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; ++i)
        {
            Destroy(enemies[i]);
        }

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        for (int i = 0; i < bullets.Length; ++i)
        {
            Destroy(bullets[i]);
        }

        for (int i = 0; i < WaveSystems.Length; ++i)
        {
            WaveSystems[i].GetComponent<WaveSpawner>().ResetWaveSystem();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("UI");
    }
}
