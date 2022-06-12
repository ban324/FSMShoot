using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFac : MonoBehaviour
{
    [SerializeField] StageData StageData;
    [SerializeField] private int Patton;
    [SerializeField] private PoolManager PoolManager;
    private void Awake()
    {
        PoolManager = GetComponent<PoolManager>();
        StartCoroutine(SelectP());
    }
    IEnumerator SelectP()
    {
        while (true)
        {
            Patton = Random.Range(0, 2);
                StartCoroutine(Normal());

        }
    }
    IEnumerator Normal()
    {
        PoolManager.ComeOn2(new Vector3 (Random.Range(StageData.Max.x, StageData.MIn.x), transform.position.y));
        
        yield return new WaitForSeconds(Random.Range(0.5f, 1.2f));
    }
}
