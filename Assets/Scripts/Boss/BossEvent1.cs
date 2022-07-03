using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEvent1 : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private Image Warning;
    [SerializeField] private float ComeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BossAppear());
    }

    IEnumerator BossAppear()
    {
        while (Warning.color.a <= 1)
        {
            Warning.color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(Time.deltaTime / 2);
        }
        StartCoroutine(BossMove());
        while (Warning.color.a >= 0)
        {
            Warning.color -= new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(Time.deltaTime / 2);
        }
    }
    IEnumerator BossMove()
    {
        while (boss.transform.position.y > 2.5)
        {
            boss.transform.position += Vector3.down * Time.deltaTime * ComeSpeed;
            yield return new WaitForSeconds(0.2f);
        }
        boss.GetComponent<Boss2Attack>().StartAttack();
        boss.GetComponent<PolygonCollider2D>().enabled = true;
        boss.GetComponent<BossHp1>().BarOn();
        yield return null;
    }
}
