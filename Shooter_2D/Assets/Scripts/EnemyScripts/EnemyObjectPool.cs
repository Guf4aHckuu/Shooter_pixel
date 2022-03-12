
public class EnemyObjectPool : ObjectPool
{
    public static EnemyObjectPool objectEnemyPool;
    public override void Awake()
    {
        objectEnemyPool = this;
    }
}
