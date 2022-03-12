using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    [SerializeField] private float _startTimeBtwSchoots;
    [SerializeField] private float _startTimeMaxtBtwReload;
    [SerializeField] private HUDManager _hudManager;
    [SerializeField] protected int _bulletCounterMax;
    [SerializeField] protected int _rangeOfBullet;
    [SerializeField] protected Transform _playerHand;
    [SerializeField] protected float _fireSpeed;
    protected int _bulletCounterCurrent;
    protected float _timeBtwShoots = 0f;
    protected float _startTimeBtwReload;

    private void Awake()
    {
        _bulletCounterCurrent = _bulletCounterMax;
        _startTimeBtwReload = _startTimeMaxtBtwReload;
    }

    private void Update()
    {
        _timeBtwShoots -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _bulletCounterCurrent > 0 && _timeBtwShoots <= 0)
        {
            //тряска камеры
            CreateBullet();
            _bulletCounterCurrent--;
            _timeBtwShoots = _startTimeBtwSchoots;
        }

        if (_bulletCounterCurrent <= 0)
        {
            Reload();
        }
        Debug.DrawRay(_playerHand.position, _playerHand.right * _rangeOfBullet, Color.green);

    }

    public virtual void CreateBullet()
    {
        GameObject bullet = ObjectPool.objectPool.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _playerHand.position;
            bullet.transform.rotation = _playerHand.rotation;
            bullet.SetActive(true);
            Rigidbody2D currentBulletVelocity = bullet.GetComponentInChildren<Rigidbody2D>();
            currentBulletVelocity.velocity = _fireSpeed * _playerHand.right;           
        }     
    }

    private void Reload()
    {
        _startTimeBtwReload -= Time.deltaTime;
        if (_startTimeBtwReload <= 0)
        {
            _bulletCounterCurrent = _bulletCounterMax;
            _startTimeBtwReload = _startTimeMaxtBtwReload;
        }
    }
}
