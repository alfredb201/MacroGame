using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    float yPosition;
    Vector3 spawnPosition;
    [SerializeField]
    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovement();
    }

    //Random positioning off screen of the round enemy
    void RandomSpawn()
    {
        yPosition = Random.Range(-4.5f, 4.5f);
        spawnPosition = new Vector3(11, yPosition, 0);
        transform.position = spawnPosition;
    }

    void ControlMovement()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            RandomSpawn();
        }
    }
}
