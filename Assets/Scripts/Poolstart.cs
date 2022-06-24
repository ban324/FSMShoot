using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolstart : MonoBehaviour
{
    [SerializeField] private Poolable poolobk1;
    [SerializeField] private Poolable poolobk2;
    [SerializeField] private Poolable poolobk3;
    [SerializeField] private Poolable poolobk4;
    private void Start()
    {
        PoolManager.Instance.Create(poolobk1);
        PoolManager.Instance.Create(poolobk2);
        PoolManager.Instance.Create(poolobk3);
        PoolManager.Instance.Create(poolobk4);
    }
}
