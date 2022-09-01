using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private AudioClip shootSound;

    private float speed = 8f;
    private float maxVelocity = 4f;

    private Rigidbody2D myBody;
   // private Animator anim;

    private bool canShoot;
    private bool canWalk;

    void Awake () {
        InitializeVariables ();
    }

    void Update () {

    }

    void FixedUpdate () {
        PlayerWalk ();
    }

    void InitializeVariables()
    {
        myBody = GetComponent<Rigidbody2D> ();
        //anim = GetComponent<Animator> ();
        canShoot = true;
        canWalk = true;
    }

    // Update is called once per frame
    void PlayerWalk()
    {
        var force = 0f;
        var velocity = Mathf.Abs (myBody.velocity.x);

        
        float h = Input.GetAxis ("Horizontal");//You can change the key diraction code

        if(h > 0)
        {
            // moving right
            if(velocity < maxVelocity)
                force = speed;

            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;

            // anim.SetBool("Walk, true);
        }
        else if(h < 0)
        {
            //moving left
             if(velocity < maxVelocity)
                force = -speed;

             Vector3 scale = transform.localScale;
             scale.x = -1;
             transform.localScale = scale;

             // anim.SetBool("Walk, true);
        }

        //prohibit the Y value
        myBody.AddForce (new Vector2(force, 0));
    }
}
