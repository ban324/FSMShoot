using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5Attack : MonoBehaviour
{
    public bool OnPatton;
    [SerializeField] private GameObject Shrimp;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Player;
    [SerializeField] private StageData stagedata;
    [SerializeField] private GameObject Warn;
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

            int i = Random.Range(0, 6);

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
    private void Patton3()
    {
        if (OnPatton == false)
        {
            StartCoroutine(P3());
        }
    }
    private void Patton4()
    {
        if (OnPatton == false)
        {
            StartCoroutine(P4());
        }
    }
    private void Patton5()
    {
        if (OnPatton == false)
        {
            StartCoroutine(P5());
        }
    }
    IEnumerator P1()
    {
        OnPatton = true;
            List<GameObject> list = new List<GameObject>();
            Vector3 PlayVec = Player.transform.position;
            float a = 0;
            int b = Random.Range(6, 9);
            for(int j = 0; j<b; j++)
            {
                GameObject obj = PoolManager.Instance.Come("EBullet");
                float z = a * Mathf.Deg2Rad;
                float x = Mathf.Sin(z);
                float y = Mathf.Cos(z);
                obj.transform.position = PlayVec+ new Vector3(x, y) * 2;
                list.Add(obj);
                a += 360/b;
            }
            yield return new WaitForSeconds(2f);
            foreach(GameObject obj in list)
            {
            if(obj == null)
            {
                continue;
            }
                obj.GetComponent<EBullet>().dir = PlayVec - obj.transform.position;
            obj.GetComponent<EBullet>().IsShrimp();
            obj.GetComponent<EBullet>().IsBoss();
            }
            yield return new WaitForSeconds(2f);
        
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
            Bullet.GetComponent<EBullet>().IsBoss(2);

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
    IEnumerator P3()
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
            bullet.GetComponent<EBullet>().IsShrimp();
        }
        OnPatton = false;
        yield return null;
    }
    IEnumerator P4()
    {
        OnPatton = true;
        for (int i = 0; i < 2; i++)
        {
            Warn.SetActive(true);
            Warn.transform.position = new Vector3(Player.transform.position.x, 0, 0);
            yield return new WaitForSeconds(1);
            Vector3 shoot = Warn.transform.position;
            Warn.SetActive(false);
            GameObject bullet = PoolManager.Instance.Come("EBullet");
            bullet.transform.position = new Vector3(shoot.x, stagedata.Max.y);
            bullet.GetComponent<EBullet>().dir = shoot - bullet.transform.position;
            yield return new WaitForSeconds(0.5f);
            for (int j = 0; j < 5; j++)
            {
                bullet = PoolManager.Instance.Come("EBullet");
                shoot.x += 1;
                bullet.transform.position = new Vector3(shoot.x, stagedata.Max.y);
                bullet.GetComponentInChildren<EBullet>().dir = shoot - bullet.transform.position;
                yield return new WaitForSeconds(0.5f);
            }
            for (int j = 0; j < 5; j++)
            {
                bullet = PoolManager.Instance.Come("EBullet");
                shoot.x -= 1;
                bullet.transform.position = new Vector3(shoot.x, stagedata.Max.y);
                bullet.GetComponentInChildren<EBullet>().dir = shoot - bullet.transform.position;
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(3);
        }
        OnPatton = false;
        yield return null;
    }
    IEnumerator P5()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject shi = Instantiate(Shrimp);
            Shrimp.transform.position = transform.position;
            shi.GetComponent<EBullet>().dir = new Vector3(Random.Range(0, 30f), Random.Range(0, 30f)).normalized;
            shi.GetComponent<EBullet>().IsShrimp();
            yield return new WaitForSeconds(0.5f);
            shi.GetComponent<EBullet>().IsBoss();
            yield return new WaitForSeconds(1f);
        }
        OnPatton = false;
        yield return null;
    }
}
