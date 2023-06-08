using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Activator : MonoBehaviour
{
    [SerializeField]
    GameObject stage2;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FlyingSprite").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= -5f)
        {
            player.position = new Vector3(-5f, player.position.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            stage2.SetActive(true);
            enabled = false;
        }
    }
}