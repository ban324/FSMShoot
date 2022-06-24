using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEvent : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private Image Warning;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BossAppear());
    }

    IEnumerator BossAppear()
    {
        for(int i = 0; i < 2; i++)
        {
            while (Warning.color.a <= 1)
            {
                Warning.color += new Color(0, 0, 0, 0.01f);
                yield return new WaitForSeconds(Time.deltaTime);
            } while (Warning.color.a >= 0)
            {
                Warning.color -= new Color(0, 0, 0, 0.01f);
                yield return new WaitForSeconds(Time.deltaTime);
            }

        }
        while (boss.transform.position.y > 2.5)
        {
            boss.transform.position += Vector3.down * 0.03f;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
