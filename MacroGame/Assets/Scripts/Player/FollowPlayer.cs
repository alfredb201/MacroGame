using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public Transform player;
    public Vector3 offset;
  
    void Update () 
    {
        transform.position = new Vector3 (player.position.x + offset.x, 0, offset.z); // Camera follows the player with specified offset position
    }
}
