using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;

    [SerializeField]
    private GameObject _bulletPrefab;

    public bool _bulletCanFire = true;

    [SerializeField]
    private int _lives = 3;
    GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();
        //character spawning
        transform.position = new Vector3(-8, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovement();

        //   FloatingEffect(1.25f, 1.5f, 2f, 3f);

       // Shoot();
    }

  /*  
   *  void FloatingEffect(float perturbationFactorUp, float perturbationFactorDown, float perturbationFactorLeft, float perturbationFactorRight)
    {
        transform.Translate(Vector3.up * (Random.Range((-1f * perturbationFactorUp), (1f * perturbationFactorDown))) * _speed * Time.deltaTime);
        transform.Translate(Vector3.right * (Random.Range((-1f * perturbationFactorLeft), (1f * perturbationFactorRight))) * _speed * Time.deltaTime);
    }
  */

    void ControlMovement()
    {
        // character movements
        float _verticalMovemet = Input.GetAxis("Vertical");
        float _horizontalMovemet = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up* _verticalMovemet * _speed * Time.deltaTime);
        transform.Translate(Vector3.right* _horizontalMovemet * _speed * Time.deltaTime);

        //setting the vertical map borders
        
        if (transform.position.y >= 1.25f)
        {
            transform.position = new Vector3(transform.position.x, 1.25f, 0);
        }
        else if (transform.position.y <= -5)
        {
            transform.position = new Vector3(transform.position.x, -5, 0);
        }

        //setting the horizontal map borders
        if (transform.position.x >= 40)
        {
            transform.position = new Vector3(40, transform.position.y, 0);
        }
        else if (transform.position.x <= -9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
    }

    public void Shoot()
    {
        var poweredUp = false;
        //Timer for the bullets cooldown
        IEnumerator BullettReloadTimer()
        {
            yield return new WaitForSeconds(.2f);
            _bulletCanFire = true;
        }
        //spawn the bullets
        if ((Input.GetButton("Fire1") || GameObject.Find("FireButton")) && _bulletCanFire)
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(1.75f, 2, 0), Quaternion.identity);
            _bulletCanFire = false;
            StartCoroutine(BullettReloadTimer());
        }
    }

    public void FireBullet()
    {
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Damage();
            Destroy(other.gameObject);
        }

        PowerUp powerUp = other.GetComponent<PowerUp>();
        if (powerUp)
        {
            if (powerUp.activateShield)
            {
                ActivateShield();
            }
            Destroy(powerUp.gameObject);
        }
    }

    void Damage()
    {

        if (HasShield())
        {
            DeactivateShield();
        }
        else
        {
            _lives--;

            if (_lives < 1)
            {
                GameManager.isGameOver = true;
                Destroy(this.gameObject);
            }
        }
    }

    void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        return shield.activeSelf;
    }
}
