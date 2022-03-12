using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] protected GameObject _bulletHandler;

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.enabled)
        {
            return;
        }

        Health obj = collision.collider.gameObject.GetComponent<Health>();
        if (obj != null)
        {
            obj.TakeDamage(_damage);
            gameObject.SetActive(false);
            return;
        } 
    }
}
