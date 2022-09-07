using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject rocket;

    [SerializeField]
    private AudioClip shootSound;

    private float speed = 8f;
    private float maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private bool canShoot;
    private bool canWalk;

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
        if (Input.GetMouseButtonDown (0))
        {
            if(canShoot)
            {
                StartCoroutine(ShootTheRocket());
            }
        }
    }

    IEnumerator ShootTheRocket()
    {
        canWalk = false;
        //anim.Play ("Shoot");
        Vector3 temp = transform.position;
        temp.y += 1f;

        Instantiate (rocket, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint (shootSound, transform.position); // !!!!

        yield return new WaitForSeconds (0.2f);
        //anim.SetBool ("Shoot", false);
        canWalk = true;

        yield return new WaitForSeconds (0.3f);
        canShoot = true;

    }

    void InitializeVariables()
    {
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        canShoot = true;
        canWalk = true;
    }

    // Update is called once per frame
    void PlayerWalk()
    {
        var force = 0f;
        var force1 = 0f;
        var velocity = Mathf.Abs (myBody.velocity.x);

        
        float h = Input.GetAxis ("Horizontal");//You can change the key diraction code
        float A = Input.GetAxis ("Vertical");

        if (canWalk) {
            if(h > 0)
            {
            // moving right
            if(velocity < maxVelocity)
                force = speed;

            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;

            //anim.SetBool("Walk, true);
            }

            else if(h < 0)
            {
                //moving left
                if(velocity < maxVelocity)
                    force = -speed;

                Vector3 scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;

                //anim.SetBool("Walk, true);
            }

        }
        
          if (canWalk) {
            if(A > 0)
            {
            // moving right
            if(velocity < maxVelocity)
                force1 = speed;

            Vector3 scale = transform.localScale;
            scale.y = 1;
            transform.localScale = scale;

            //anim.SetBool("Walk, true);
            }
            else if(A < 0)
            {
                //moving left
                if(velocity < maxVelocity)
                    force1 = -speed;

                Vector3 scale = transform.localScale;
                scale.y = 1;
                transform.localScale = scale;

                //anim.SetBool("Walk, true);
            }

        }


        myBody.AddForce (new Vector2(force, 0));
        myBody.AddForce (new Vector2(0, force1));
    }

    void OnCollisionEnter2D(Collider2D pCollidedGameObject)
    {
            Destroy(this.gameObject);
    }
}
