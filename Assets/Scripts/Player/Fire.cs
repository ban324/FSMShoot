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
    [SerializeField] private bool OnShoot = false;
    public float delay
    {
        get { return Delay; }
        set { Delay = value; }
    }
    private void Awake()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnShoot = true;
            StartCoroutine(Firing());
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            OnShoot = false;
            StopAllCoroutines();
        }
    }
    IEnumerator Firing()
    {
        while (true)
        {
            if (OnShoot)
            {
                poolManager.ComeOn(transform.position);
            }
            yield return new WaitForSeconds(Delay);
            poolManager.ComeOn(transform.position);

        }
    }
}
