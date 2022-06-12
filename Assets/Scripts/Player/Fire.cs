using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject Bullet1;
    [SerializeField] private int WeaponLevel;
    [SerializeField] private GameObject Bullet2;
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private GameObject Bullet3;
    [SerializeField] private float Delay;

    private void Awake()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Firing());
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            StopAllCoroutines();
        }
    }
    IEnumerator Firing()
    {
        while (true)
        {
            poolManager.ComeOn(transform.position);
            yield return new WaitForSeconds(Delay);
        }
    }
}
