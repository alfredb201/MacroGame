using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour
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

        if (player.position.x >= 9)
        {
            player.position = new Vector3(9, player.position.y, 0);
        }

        if (transform.childCount == 0)
        {
            camLock.GetComponent<FollowPlayer>().enabled = true;
            clouds.GetComponent<CloudsMovement>().enabled = true;
            enabled = false;
        }

    }
}
