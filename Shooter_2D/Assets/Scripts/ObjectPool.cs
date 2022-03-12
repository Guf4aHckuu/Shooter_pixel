using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool objectPool;
    [SerializeField] protected List<GameObject> _pooledObjects;
    [SerializeField] protected GameObject _objectToPool;
    [SerializeField] protected int _amountToPool;
    public virtual void Awake()
    {
        objectPool = this;
    }

    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}
