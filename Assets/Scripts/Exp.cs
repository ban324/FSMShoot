using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField]WeaponLevel weapon;
    private void Awake()
    {
        weapon = GameObject.Find("Manager").GetComponent<WeaponLevel>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            weapon.GetExp(Score);
        }
    }
}
