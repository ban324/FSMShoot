using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Attack : MonoBehaviour
{
    public bool OnPatton;
    [SerializeField] private GameObject Warn;
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
        OnPatton = true;
        for(int i = 0; i < 2; i++)
        {
            Warn.SetActive(true);
            Warn.transform.position = new Vector3(Player.transform.position.x, 0, 0);
            yield return new WaitForSeconds(1);
            Vector3 shoot = Warn.transform.position;
            Warn.SetActive(false);
            GameObject bullet =  PoolManager.Instance.Come("EBullet");
            bullet.transform.position = new Vector3(shoot.x, stagedata.Max.y);
            bullet.GetComponent<EBullet>().dir = shoot - bullet.transform.position;
            yield return new WaitForSeconds(0.5f);
            for(int j =0; j<5; j++)
            {
                bullet = PoolManager.Instance.Come("EBullet");
                shoot.x += 1;
                bullet.transform.position = new Vector3(shoot.x, stagedata.Max.y);
                bullet.GetComponentInChildren<EBullet>().dir = shoot - bullet.transform.position;
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(3);
        }
        OnPatton = false;
        yield return null;
    }
    IEnumerator P2()
    {
        OnPatton = true;
        a = 120;
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(a);
            float z = a * Mathf.Deg2Rad;
            x = Mathf.Sin(z);
            y = Mathf.Cos(z);
            GameObject Bullet = PoolManager.Instance.Come("EBullet");
            Bullet.transform.position = transform.position + new Vector3(0, -2f);
            Bullet.GetComponent<EBullet>().dir = new Vector3(x, y);
            Bullet.GetComponent<EBullet>().IsBoss();
            yield return new WaitForSeconds(0.2f);
            Bullet.GetComponent<EBullet>().IsBoss();
            a = a + 15;
            yield return new WaitForSeconds(1/3f);
        }
        for(int i = 0; i < 6; i++)
        {
            Debug.Log(a);
            float z = a * Mathf.Deg2Rad;
            x = Mathf.Sin(z);
            y = Mathf.Cos(z);
            GameObject Bullet = PoolManager.Instance.Come("EBullet");
            Bullet.transform.position = transform.position + new Vector3(0, -2f);
            Bullet.GetComponent<EBullet>().dir = new Vector3(x, y);
            Bullet.GetComponent<EBullet>().IsBoss();
            yield return new WaitForSeconds(0.2f);
            Bullet.GetComponent<EBullet>().IsBoss();

            a = a - 15;
            yield return new WaitForSeconds(1/3f);
        }
        OnPatton = false;
        yield return null;
    }
}
