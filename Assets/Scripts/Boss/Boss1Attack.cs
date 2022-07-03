using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Attack : MonoBehaviour
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
        for (int i = 0; i < 2; i++)
        {
            OnPatton = true;
            yield return new WaitForSeconds(1);
            Warn.SetActive(true);
            Warn.GetComponent<Warning>().OnActive();
            if (Random.Range(0, 2) == 1)
            {
                x = stagedata.Max.x;
                y = Random.Range(stagedata.Max.y, stagedata.Max.y);
            }
            else
            {
                x = Random.Range(stagedata.MIn.x, stagedata.Max.x);
                y = stagedata.MIn.y;
            }
            Warn.transform.position = new Vector3(x, y, 0);
            float z = Mathf.Atan2(Player.transform.position.y - y, Player.transform.position.x - x);
            z = z * Mathf.Rad2Deg;

            Warn.transform.rotation = Quaternion.Euler(0, 0, z - 90);
            Vector3 Route = Player.transform.position - Warn.transform.position;
            yield return new WaitForSeconds(1f);
            Warn.GetComponent<Warning>().OnFalsed();
            Warn.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            GameObject bullet = PoolManager.Instance.Come("EBullet");
            Route = Route.normalized * 8;

            bullet.GetComponent<EBullet>().dir = Route;

            bullet.transform.position = Warn.transform.position;
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
            Bullet.GetComponent<EBullet>().IsBoss();
            a = a - 30;
            yield return new WaitForSeconds(1/3f);
        }
        OnPatton = false;
        yield return null;
    }
}
