using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Manager : MonoBehaviour
{
    private GameObject camLock;

    private Transform player;

    private GameObject clouds;
    // Update is called once per frame
    void Start()
    {
        camLock = GameObject.Find("MainCamera");

        camLock.GetComponent<FollowPlayer>().enabled = false;

        player = GameObject.Find("FlyingSprite").transform;

        clouds = GameObject.Find("Clouds");

        clouds.GetComponent<CloudsMovement>().enabled = false;
    }

    void Update()
    {
        //set the horizontal borders for the stage
        if (transform.childCount > 1)
        {
            if (player.position.x >= 23)
            {
                player.position = new Vector3(23, player.position.y, 0);
            }
            else if (player.position.x <= 5)
            {
                player.position = new Vector3(5, player.position.y, 0);
            }
        }

        if (transform.childCount < 1)
        {
            camLock.GetComponent<FollowPlayer>().enabled = true;
            clouds.GetComponent<CloudsMovement>().enabled = true;
            enabled = false;
        }

    }
}
