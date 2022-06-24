using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int Damage;

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
    }
}
