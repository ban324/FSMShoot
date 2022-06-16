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
        StartCoroutine(Normal());
    }
    IEnumerator Normal()
    {
        while (true)
        {
            PoolManager.ComeOn(new Vector3(Random.Range(StageData.Max.x, StageData.MIn.x), StageData.Max.y + 0.5f));

            yield return new WaitForSeconds(Random.Range(0.5f ,1.0f));
        }
    }
}
