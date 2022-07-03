using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private EnemyHp HP;
    private void Start()
    {
        HP = GetComponent<EnemyHp>();
    }
    public void MoveStart()
    {
        StartCoroutine(Moving());

    }

    IEnumerator Moving()
    {
        Debug.Log("sdfa");
        while(transform.position.y > 1.3f)
        {
            transform.position += dir * speed *Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        float i = 0;
        float j = 0;
        while(i < 9)
        {
            GameObject a = PoolManager.Instance.Come("EBullet");
            a.transform.position = transform.position;

            float k = Mathf.Deg2Rad * j;
            a.GetComponent<EBullet>().dir = new Vector3(Mathf.Sin(k), Mathf.Cos(k));
            j += 40;
            i++;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        while (true)
        {
            transform.position += dir * speed * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void Die()
    {
        if (Random.Range(0, 2) == 1)
        {
            GameObject Exp = PoolManager.Instance.Come("LifeIcon");
            Exp.transform.position = transform.position;
        }
        Score.instance.Shootdown++;

        PoolManager.Instance.Pushing(gameObject.name, gameObject);

    }
}
