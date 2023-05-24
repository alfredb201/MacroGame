using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Manager : MonoBehaviour
{
    private GameObject camLock;

    private Transform player;
    // Update is called once per frame
    void Start()
    {
        camLock = GameObject.Find("MainCamera");

        camLock.GetComponent<FollowPlayer>().enabled = false;

        player = GameObject.Find("FlyingSprite").transform;
    }

    void Update()
    {
        //set the horizontal borders for the stage

        if (player.position.x >= 26.5f)
        {
            player.position = new Vector3(26.5f, player.position.y, 0);
        }
        else if (player.position.x <= 9)
        {
            player.position = new Vector3(9, player.position.y, 0);
        }

        if (transform.childCount < 1)
        {
            camLock.GetComponent<FollowPlayer>().enabled = true;
            enabled = false;
        }

    }
}
