using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private EnemyHp HP;
    [SerializeField] private GameObject Score;
    private void Awake()
    {
        HP = GetComponent<EnemyHp>();
    }
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }


    public void Die()
    {
        if (Random.Range(0, 2) == 1)
        {
            GameObject Exp = PoolManager.Instance.Come("LifeIcon");
            Exp.transform.position = transform.position;
        }
        PoolManager.Instance.Pushing(gameObject.name, gameObject);

    }
}
