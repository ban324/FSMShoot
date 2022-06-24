using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private int Hp = 1;
    [SerializeField] private Color color;
    [SerializeField] private SpriteRenderer sprite;
    public int hp
    {
        get { return Hp; }
        set { Hp = value; }
    }
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }
    public void OnHited(int Damage)
    {
        Hp -= Damage;
        if (Hp < 1)
        {
            enemy.Die();
        }
    }
}
