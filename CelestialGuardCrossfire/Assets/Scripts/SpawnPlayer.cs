using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objectToSpawn, Vector2.zero, Quaternion.identity);
    }
}
