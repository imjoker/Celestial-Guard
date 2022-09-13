using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    public GameObject bullet;
    private bool canShoot = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if ((transform.position.y - player.transform.position.y) < 8f)
                StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        Vector3 temp = transform.position;
        temp.y -= 1f;

        Instantiate(bullet, temp, Quaternion.identity);

        yield return new WaitForSeconds(1f);

        canShoot = true;

        yield break;
    }
}
