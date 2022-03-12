using UnityEngine;

public class FlamController : EnemyController
{
    [SerializeField] private float _shootingPower;

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _timeBtwAttack -= Time.deltaTime;
        }
    }

    public override void Update()
    {
        if (_timeBtwAttack <= 0)
        {
            CreateBulletByFlam();
            _timeBtwAttack = _maxTimeBtwAttack;
        }
        base.Update();
    }

    private void CreateBulletByFlam()
    {
        GameObject bullet = EnemyObjectPool.objectEnemyPool.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            Vector2 direction = _target.position - transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * _shootingPower;
        }
    }
}
