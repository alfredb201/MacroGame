using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLocking : MonoBehaviour
{
    GameObject camLock;
    // Start is called before the first frame update
    void Start()
    {
        camLock = GameObject.Find("MainCamera");

        camLock.GetComponent<FollowPlayer>().enabled = false;

    }

    void Update()
    {
        
    }

    public void EnableCam()
    { 
        camLock.GetComponent<FollowPlayer>().enabled = true;
    }

    public void DisableCam()
    {
        camLock.GetComponent<FollowPlayer>().enabled = false;
    }
}
