using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingLogic : MonoBehaviour
{

    [SerializeField]
    private GameObject _bulletPrefab;

    private bool _bulletCanFire = true;

    // Update is called once per frame
    void Update()
    {
        //Timer for the bullets cooldown
        IEnumerator BullettReloadTimer()
        {
            yield return new WaitForSeconds(2);
            _bulletCanFire = true;
        }

        //spawn the bullets
        if (_bulletCanFire)
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
            _bulletCanFire = false;
            StartCoroutine(BullettReloadTimer());
        }
    }
}
