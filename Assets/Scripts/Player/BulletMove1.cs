using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PoolManager poolManager2;
    [SerializeField] private int Damage;
    private void Awake()
    {
        poolManager2 = GameObject.Find("Player").GetComponent<PoolManager>();
        GetComponent<AutoReturner2>().poolManager = poolManager2;
    }
    private void Update()
    {
        
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHp>().OnHited(Damage);
            poolManager2.Returner(gameObject);

        }
    }

}
