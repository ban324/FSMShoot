using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    public Vector3 dir;
    public StageData stagedata;
    private bool shirimp = false;
    [SerializeField] private float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dir = Vector3.zero;
            if (shirimp!) { PoolManager.Instance.Pushing(gameObject.name, gameObject); }
            else { Destroy(gameObject); }
        }
    }
    public void IsBoss(int z = 1)
    {
        if(z == 1)
        {
            StartCoroutine(Mandara());
        }
        if(z == 2)
        {
            StartCoroutine(Mandara2());

        }
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    IEnumerator Mandara()
    {

            float a = 0;
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i<6; i++)
        {

            GameObject Clone = PoolManager.Instance.Come(gameObject.name);
            Clone.transform.position = gameObject.transform.position;
            float z = a * Mathf.Deg2Rad;
            Clone.GetComponent<EBullet>().dir = new Vector3(Mathf.Sin(z), Mathf.Cos(z), 0).normalized * 0.5f;
            a += 60;
            if (a == 360)
            {
                a = 0;
            }
        }
        yield return null;
        
    }    IEnumerator Mandara2()
    {

            float a = 0;
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i<7; i++)
        {

            GameObject Clone = PoolManager.Instance.Come(gameObject.name);
            Clone.transform.position = gameObject.transform.position;
            float z = a * Mathf.Deg2Rad;
            Clone.GetComponent<EBullet>().dir = new Vector3(Mathf.Sin(z), Mathf.Cos(z), 0).normalized * 0.5f;
            a += 51.4f;
            if (a == 360)
            {
                a = 0;
            }
        }
        yield return null;
        
    }
    public void IsShrimp()
    {
        shirimp = true;
        StartCoroutine(Shrimp());
    }
    IEnumerator Shrimp()
    {
        int z = 0;
        while(z < 3)
        {
            if(transform.position.x >= stagedata.Max.x || transform.position.x <= stagedata.MIn.x)
            {
                dir = new Vector3(-dir.x, dir.y);
                z++;
            }
            if(transform.position.y >= stagedata.Max.y || transform.position.y <= stagedata.MIn.y)
            {
                dir = new Vector3(dir.x, -dir.y);
                z++;
            }
            yield return null;
        }
        yield return null;
    }
}
