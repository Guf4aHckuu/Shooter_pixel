using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _damage;
    [SerializeField] protected float _maxTimeBtwAttack;
    [SerializeField] protected Transform _target;
    private NavMeshAgent _navMeshAgent;
    private EnemyHealth _enemyHealth;
    protected Animator _animByEnemy;
    public float _timeBtwAttack = 0.1f;

    public void ConstructSpawner(Transform target)
    {
        _target = target;
        _playerHealth = _target.GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _animByEnemy = GetComponent<Animator>();
        _navMeshAgent.updateUpAxis = false;
        _navMeshAgent.updateRotation = false;
    }

    public virtual void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
        if (_enemyHealth._health <= 0)
        {
            _navMeshAgent.speed = 0f;
        }
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_timeBtwAttack <= 0)
            {
                _animByEnemy.SetTrigger("Attack");
                _playerHealth.TakeDamage(_damage);
                _timeBtwAttack = _maxTimeBtwAttack;
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;
            }
        }
    }
}
