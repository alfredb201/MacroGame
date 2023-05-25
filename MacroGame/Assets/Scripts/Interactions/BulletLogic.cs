using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (transform.position.x >= (spawnPosition.x + 23))
        {
            Destroy(gameObject); 
        }
    }
}
