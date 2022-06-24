using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove1 : MonoBehaviour
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
            Destroy(gameObject);
        }
    }

}
