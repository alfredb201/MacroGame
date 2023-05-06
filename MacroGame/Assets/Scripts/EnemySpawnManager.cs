using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab1;

    [SerializeField]
    private GameObject _enemyPrefab2;

    [SerializeField]
    private GameObject _containerTypeEnemy1;

    [SerializeField]
    private GameObject _containerTypeEnemy2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    } 

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 posToSpawn1 = new Vector3(11, Random.Range(-4.5f, 4.5f), 0);
            GameObject newEnemy1 = Instantiate(_enemyPrefab1, posToSpawn1, Quaternion.identity);
            newEnemy1.transform.parent = _containerTypeEnemy1.transform;

            Vector3 posToSpawn2 = new Vector3(11, Random.Range(-4.5f, 4.5f), 0);
            GameObject newEnemy2 = Instantiate(_enemyPrefab2, posToSpawn2, Quaternion.identity);
            newEnemy2.transform.parent = _containerTypeEnemy2.transform;

            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }
}
