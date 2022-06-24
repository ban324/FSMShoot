using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private int Score;
    private void Awake()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponLevel.Instance.GetExp(Score);
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
    }
}
