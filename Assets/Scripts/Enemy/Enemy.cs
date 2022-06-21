using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] private float speed;
    public PoolManager poolManager;
    [SerializeField] private EnemyHp HP;
    private void Awake()
    {
        HP = GetComponent<EnemyHp>();
        poolManager = GameObject.Find("EnemyFactory").GetComponent<PoolManager>();
        GetComponent<AutoReturner1>().poolManager = poolManager;
    }
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Die();
        }
    }

    public void Die()
    {
        if (Random.Range(0, 2) == 1)
        {
            poolManager.ComeOn2(transform.position);
        }
        Debug.Log(gameObject.name);

        poolManager.Returner(gameObject);
    }
}
