using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;

    [SerializeField]
    private GameObject _bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //character spawning
        transform.position = new Vector3(-8, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovement();

        //spawn the bullets
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(0.75f, 0 , 0), Quaternion.identity);
        }
    }

    void ControlMovement()
    {
        // character movements
        float _verticalMovemet = Input.GetAxis("Vertical");
        float _horizontalMovemet = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up* _verticalMovemet * _speed * Time.deltaTime);
        transform.Translate(Vector3.right* _horizontalMovemet * _speed * Time.deltaTime);

        //setting the vertical map borders
        if (transform.position.y >= 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
        }
        else if (transform.position.y <= -4.5f)
        {
    transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }

        //setting the horizontal map borders
        if (transform.position.x >= 0)
        {
            transform.position = new Vector3(0, transform.position.y, 0);
        }
        else if (transform.position.x <= -9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
    }
}
