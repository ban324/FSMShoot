using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private float Hp = 1;
    [SerializeField] private Color color;
    [SerializeField] private SpriteRenderer sprite;
    public float hp
    {
        get { return Hp; }
        set { Hp = value; }
    }
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }
    public void OnHited(float Damage)
    {
        Hp -= Damage;
        if (Hp <= 0)
        {
            enemy.Die();
        }
    }
}
