using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject Bullet1;
    [SerializeField] private GameObject Bullet2;
    [SerializeField] private GameObject Bullet3;
    [SerializeField] private float Delay;
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
            yield return new WaitForSeconds(Delay);

            GameObject bullet1 = PoolManager.Instance.Come("SBullet").gameObject;
            bullet1.transform.position = transform.position;

        }
    }
}
