using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private pool _pool;
    Dictionary<string, pool> _pools = new Dictionary<string, pool>();
    [SerializeField] private GameObject preobj;
    static public PoolManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void Create(Poolable obj)
    {
        pool Pool = new pool();
        Pool.init(obj, 5);
        _pools.Add(obj.gameObject.name ,Pool);
    }
    public GameObject Come(string name)
    {
        Poolable a = _pools[name].Pop();
        return a.gameObject;
    }
    public void Pushing(string name,GameObject obj)
    {
        _pools[name].push(obj.GetComponent<Poolable>());
    }
}
