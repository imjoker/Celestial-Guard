using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        Vector2 newpos      = transform.position;
        newpos.y            = newpos.y - 0.001f;
        transform.position  = newpos;
    }   
}
