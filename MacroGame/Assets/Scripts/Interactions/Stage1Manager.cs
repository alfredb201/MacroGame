using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour
{
    GameObject camLock;
    // Update is called once per frame
    void Start()
    {
        camLock = GameObject.Find("MainCamera");

        camLock.GetComponent<FollowPlayer>().enabled = false;
    }

    void Update()
    {
        if (transform.childCount < 1)
        {
            camLock.GetComponent<FollowPlayer>().enabled = true;
        }
    }
}
