using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptByEnemy : BulletScript
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            if (collision.gameObject.name != "Fireball_0(Clone)")
            {
                base.OnCollisionEnter2D(collision);
            }       
        }       
    }
}
