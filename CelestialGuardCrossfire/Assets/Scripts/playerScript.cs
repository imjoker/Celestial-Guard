using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
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


    private float speed = 8f;
    private float maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private bool canShoot;

    public GameObject bottomBorder;
    public GameObject topBorder;

    void Awake () {
        InitializeVariables ();
    }

    void Update () {
        Shoot ();
    }

    void FixedUpdate () {
        PlayerWalk ();
    }

    void Shoot() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(canShoot)
            {
                StartCoroutine(ShootThetop_rocket());
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (canShoot)
            {
                StartCoroutine(ShootTheLeft_rocket());
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (canShoot)
            {
                StartCoroutine(ShootTheBottom_rocket());
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (canShoot)
            {
                StartCoroutine(ShootTheRight_rocket());
            }
        }
    }

    IEnumerator ShootThetop_rocket()
    {
        //anim.Play ("Shoot");
        Vector3 temp = transform.position;
        temp.y += 1f;

        Instantiate (top_rocket, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint (shootSound, transform.position); // !!!!

        yield return new WaitForSeconds (0.3f);

        //anim.SetBool ("Shoot", false);

        canShoot = true;

    }

    IEnumerator ShootTheRight_rocket()
    {
        //anim.Play ("Shoot");
        Vector3 temp = transform.position;
        temp.x += 1f;

        Instantiate(right_rocket, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint(shootSound, transform.position); // !!!!

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
    }

    // Update is called once per frame
    void PlayerWalk()
    {
        var force = 0f;
        var force1 = 0f;
        var velocity = Mathf.Abs (myBody.velocity.x);

        
        float h = Input.GetAxis ("Horizontal");//You can change the key diraction code
        float A = Input.GetAxis ("Vertical");

        
        if(h > 0)
        {
        // moving right
        if(velocity < maxVelocity)
            force = speed;

        Vector3 scale = transform.localScale;
        //scale.x = 1;
        transform.localScale = scale;

        //anim.SetBool("Walk, true);
        }

        else if(h < 0)
        {
            //moving left
            if(velocity < maxVelocity)
                force = -speed;

            Vector3 scale = transform.localScale;
            //scale.x = -1;
            transform.localScale = scale;

            //anim.SetBool("Walk, true);
        }

        
        if(A > 0)
        {
        // moving right
        if(velocity < maxVelocity)
            force1 = speed;

        Vector3 scale = transform.localScale;
        //scale.y = 1;
        transform.localScale = scale;

        //anim.SetBool("Walk, true);
        }
        else if(A < 0)
        {
            //moving left
            if(velocity < maxVelocity)
                force1 = -speed;

            Vector3 scale = transform.localScale;
            //scale.y = 1;
            transform.localScale = scale;

            //anim.SetBool("Walk, true);
        }

        myBody.AddForce (new Vector2(force, 0));
        myBody.AddForce (new Vector2(0, force1));
    }

    void OnCollisionEnter2D(Collision2D pCollidedGameObject)
    {
        if (pCollidedGameObject.gameObject.CompareTag("Enemy"))
        {
            if (lives > 0)
            {
                Respawn();
            }
            else
            {
                SceneManager.LoadScene("UI");
            }
        }
    }

    void Respawn ()
    {
        lives -= 1;
        transform.position = playerBegin;
    }
}
