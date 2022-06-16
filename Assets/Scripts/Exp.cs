using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] PoolManager poolmanager;
    private void Awake()
    {
        poolmanager = GameObject.Find("EnemyFactory").GetComponent<PoolManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponLevel.Instance.GetExp(Score);
            poolmanager.Returner2(gameObject);
        }
    }
}
