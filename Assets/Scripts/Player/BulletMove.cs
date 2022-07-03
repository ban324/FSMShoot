using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Damage;

    private void Awake()
    {
    }
    private void Update()
    {
        
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().OnHited(Damage);
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHp>().OnDamage(Damage);
            
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
        if (collision.CompareTag("Boss1"))
        {
            collision.GetComponent<BossHp1>().OnDamage(Damage);
            
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
        if (collision.CompareTag("Boss2"))
        {
            collision.GetComponent<BossHp2>().OnDamage(Damage);
            
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
        if (collision.CompareTag("Boss3"))
        {
            collision.GetComponent<BossHp3>().OnDamage(Damage);
            
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
        if (collision.CompareTag("FinalBoss"))
        {
            collision.GetComponent<BossHp4  >().OnDamage(Damage);
            
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
    }
}
