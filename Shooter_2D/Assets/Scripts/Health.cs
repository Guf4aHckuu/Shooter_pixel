using UnityEngine;

public class Health : MonoBehaviour
{
    public float _health;

    public virtual void TakeDamage(float iDamage)
    {
        _health -= iDamage;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 1);
        Invoke("ChangeColorByHitToDefault", 0.1f);
        if (_health <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    public void ChangeColorByHitToDefault()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }
}
