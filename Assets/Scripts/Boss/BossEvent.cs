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
        while(boss.transform.position.y > 2.5)
        {
            boss.transform.position += Vector3.down * 0.05f;
            Warning.color += new Color(0,0,0,0.05f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while(Warning.color.a > 0)
        {
            Warning.color -= new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
