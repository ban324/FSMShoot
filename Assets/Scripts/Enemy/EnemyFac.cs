using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFac : MonoBehaviour
{
    [SerializeField] StageData StageData;
    [SerializeField] private int Patton;
    [SerializeField] private GameObject enemy;
    private void Start()
    {
        StartCoroutine(Normal());
    }
    IEnumerator Normal()
    {
        while (true)
        {
            GameObject obj = PoolManager.Instance.Come("MeatBall");
            obj.transform.position = new Vector3(Random.Range(StageData.MIn.x, StageData.Max.x), StageData.Max.y + 0.5f);
            yield return new WaitForSeconds(Random.Range(0.5f ,1.0f));
        }
    }
}
