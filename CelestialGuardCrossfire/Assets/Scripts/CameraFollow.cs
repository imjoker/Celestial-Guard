using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    private Camera mainCamera;
    public GameObject bottomBorder;
    public GameObject topBorder;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        while (mainCamera == null)
            mainCamera = GetComponent<Camera>();

        Vector3 vec = new Vector3(transform.position.x, (Player.transform.position.y + ((2 * mainCamera.orthographicSize) / 3)), -10);

        if ((vec.y - bottomBorder.transform.position.y) < mainCamera.orthographicSize)
        {
            vec.y = bottomBorder.transform.position.y + mainCamera.orthographicSize;
        }
        else if ((topBorder.transform.position.y - vec.y) < mainCamera.orthographicSize)
        {
            vec.y = topBorder.transform.position.y - mainCamera.orthographicSize;
        }

        transform.position = vec;
    }
}
