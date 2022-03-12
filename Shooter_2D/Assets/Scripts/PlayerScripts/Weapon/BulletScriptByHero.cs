using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptByHero : BulletScript
{
    private void Start()
    {
        _bulletHandler = GameObject.FindGameObjectWithTag("Hand");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _bulletHandler.transform.position) > 10f)
        {
            gameObject.SetActive(false);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "01(Clone)")
        {
            gameObject.SetActive(false);
        } 
        base.OnCollisionEnter2D(collision);
    }
}
