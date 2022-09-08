using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemey : MonoBehaviour
{
    private Rigidbody2D rb;
    private float       elapsed_time = 0f;
    public  float       desired_duration = 30f;
    private Vector2     playerpos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
