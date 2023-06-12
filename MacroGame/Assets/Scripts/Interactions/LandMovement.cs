using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;
    public PlayerTouchMovement touch;
    private Transform player;
    private void Start()
    {
        touch = GameObject.Find("FlyingSprite").GetComponent<PlayerTouchMovement>();
        player = GameObject.Find("FlyingSprite").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= -5f)
        {
            player.position = new Vector3(-5f, player.position.y, 0);
        }
        else 
        {
            float _horizontalMovemet = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.left * _horizontalMovemet * _speed * Time.deltaTime);
            float _horizontalMovemetTouch = touch.MovementAmount.x;
            transform.Translate(Vector3.left * _horizontalMovemetTouch * _speed * Time.deltaTime);
        }
    }
}
