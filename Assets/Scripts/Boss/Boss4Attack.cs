using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Attack : MonoBehaviour
{
    public bool OnPatton;
    [SerializeField] private GameObject Shrimp;
    [SerializeField] private Animator animator;
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
            List<GameObject> list = new List<GameObject>();
            Vector3 PlayVec = Player.transform.position;
            float a = 0;
            int b = Random.Range(4, 8);
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
}
