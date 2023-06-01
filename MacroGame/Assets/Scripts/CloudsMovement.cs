using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;
    public PlayerTouchMovement touch;
    private void Start()
    {
        touch = GameObject.Find("FlyingSprite").GetComponent<PlayerTouchMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        float _horizontalMovemet = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * _horizontalMovemet * _speed * Time.deltaTime);
        float _horizontalMovemetTouch = touch.MovementAmount.x;
        transform.Translate(Vector3.left * _horizontalMovemetTouch * _speed * Time.deltaTime);
    }
}
