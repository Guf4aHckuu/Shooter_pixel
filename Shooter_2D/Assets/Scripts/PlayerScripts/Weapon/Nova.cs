using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nova : WeaponLogic
{
    public override void Update()
    {
        _currentBulletText.text = _bulletCounterCurrent.ToString() + "/" + _bulletCounterMax.ToString();
        base.Update();
    }

    public override void CreateBullet()
    {
        for (int i = 0; i < 3; i++)
        {        
            GameObject bullet = ObjectPool.objectPool.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = _playerHand.position;
                bullet.transform.rotation = Quaternion.Euler(_playerHand.eulerAngles.x + 10f, _playerHand.eulerAngles.y, _playerHand.eulerAngles.z);
                bullet.SetActive(true);
                Rigidbody2D currentBulletVelocity = bullet.GetComponentInChildren<Rigidbody2D>();
                currentBulletVelocity.velocity = _fireSpeed * _playerHand.right;
            }                       
        }   
    }
}
