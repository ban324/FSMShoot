using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] private float speed;
    public PoolManager poolManager;
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        poolManager.Returner(gameObject);
    }
}
