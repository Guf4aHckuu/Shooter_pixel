using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private float _startTimeBtwSchoots;
    [SerializeField] private float _startTimeMaxtBtwReload;
    [SerializeField] private int _bulletCounterMax;
    [SerializeField] private int _rangeOfBullet;
    [SerializeField] private Transform _playerHand;
    private int _bulletCounterCurrent;
    private float _timeBtwShoots;
    private float _StartTimeBtwReload;

    private void Awake()
    {
        _bulletCounterCurrent = _bulletCounterMax;
        _timeBtwShoots = _startTimeBtwSchoots;
    }
    private void Update()
    {
        _timeBtwShoots -= Time.deltaTime;
        if(Input.GetMouseButton(0) && _bulletCounterCurrent != 0 && _timeBtwShoots <= 0)
        {
            //тряска камеры
            SchootParticle();
            DamageByWeapon(); 
            _bulletCounterCurrent--;
            _timeBtwShoots = _startTimeBtwSchoots;

            Debug.Log(_bulletCounterCurrent);
        }

        if(_bulletCounterCurrent <= 0)
        {
            Reload();
        }
    }

    private void DamageByWeapon()
    {
        Vector2 endPosition = transform.position + Vector3.forward * _rangeOfBullet;
        RaycastHit2D hit = Physics2D.Linecast(_playerHand.position, endPosition);

        Health health = hit.transform.GetComponent<Health>();
        if(hit.collider != null)
        {
            if (health != null)
            {
                health.TakeDamage(_damage);
            }
        }
            
    }

    private void SchootParticle()
    {
        GameObject bullet = ObjectPool.objectPool.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _playerHand.position;
            bullet.transform.rotation = _playerHand.rotation;
            bullet.SetActive(true);
            Rigidbody2D currentBulletVelocity = bullet.GetComponentInChildren<Rigidbody2D>();
            currentBulletVelocity.velocity = _fireSpeed * _playerHand.forward;
        }
    }

    private void Reload()
    {
        _StartTimeBtwReload -= Time.deltaTime;
        if(_StartTimeBtwReload <= 0)
        {
            _bulletCounterCurrent = _bulletCounterMax;
            _StartTimeBtwReload = _startTimeMaxtBtwReload;
        }
    }
}
