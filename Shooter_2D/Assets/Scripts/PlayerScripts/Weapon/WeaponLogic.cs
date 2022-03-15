using UnityEngine;
using UnityEngine.UI;

public class WeaponLogic : MonoBehaviour
{
    [SerializeField] private float _startTimeBtwSchoots;
    [SerializeField] private float _startTimeMaxtBtwReload;
    [SerializeField] private Text _currentBulletText;
    [SerializeField] protected int _bulletCounterMax;
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

    public virtual void Update()
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

        _currentBulletText.text = _bulletCounterCurrent.ToString() + "/" + _bulletCounterMax.ToString();
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
