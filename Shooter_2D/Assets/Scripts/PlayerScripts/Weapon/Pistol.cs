using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponLogic
{
    public override void Update()
    {
        _currentBulletText.text = _bulletCounterCurrent.ToString() + "/" + _bulletCounterMax.ToString();
        base.Update();
    }
}
