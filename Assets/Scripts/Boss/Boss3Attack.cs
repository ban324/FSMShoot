using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Attack : MonoBehaviour
{
    public bool OnPatton;
    [SerializeField] private GameObject Shrimp;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Player;
    [SerializeField] private StageData stagedata;
    float x;
    float a;
    float y;

    public void StartAttack()
    {
        StartCoroutine(Select());
    }

    IEnumerator Select()
    {
        while (true)
        {

            int i = Random.Range(0, 2);

            if (i == 0) { Patton1(); }
            if (i == 1) { Patton2(); }
            yield return new WaitForSeconds(1);
        }
    }
    private void Patton1()
    {
        if (OnPatton == false)
        {
            StartCoroutine(P1());
        }
    }
    private void Patton2()
    {
        if (OnPatton == false)
        {
            StartCoroutine(P2());
        }
    }
    IEnumerator P1()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject shi = Instantiate(Shrimp);
            Shrimp.transform.position = transform.position;
            shi.GetComponent<EBullet>().dir = new Vector3(Random.Range(0, 30f), Random.Range(0, 30f)).normalized;
            shi.GetComponent<EBullet>().IsShrimp();
            yield return new WaitForSeconds(1f);
        }
        OnPatton = false;
        yield return null;
    }
    IEnumerator P2()
    {
        OnPatton = true;
        a = 120;
        for(int i = 0; i < 3; i++)
        {
            Debug.Log(a);
            float z = a * Mathf.Deg2Rad;
            x = Mathf.Sin(z);
            y = Mathf.Cos(z);
            GameObject Bullet = PoolManager.Instance.Come("EBullet");
            Bullet.transform.position = transform.position + new Vector3(0, -2f);
            Bullet.GetComponent<EBullet>().dir = new Vector3(x, y);
            Bullet.GetComponent<EBullet>().IsBoss();
            a = a + 30;
            yield return new WaitForSeconds(1/3f);
        }
        for(int i = 0; i < 4; i++)
        {
            Debug.Log(a);
            float z = a * Mathf.Deg2Rad;
            x = Mathf.Sin(z);
            y = Mathf.Cos(z);
            GameObject Bullet = PoolManager.Instance.Come("EBullet");
            Bullet.transform.position = transform.position + new Vector3(0, -2f);
            Bullet.GetComponent<EBullet>().dir = new Vector3(x, y);
            Bullet.GetComponent<EBullet>().IsBoss(2);
            a = a - 30;
            yield return new WaitForSeconds(1/3f);
        }
        OnPatton = false;
        yield return null;
    }
}
