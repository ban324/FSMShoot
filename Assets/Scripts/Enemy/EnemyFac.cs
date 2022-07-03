using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFac : MonoBehaviour
{
    [SerializeField] StageData StageData;
    [SerializeField] private int Patton;
    [SerializeField] private GameObject enemy;
    [SerializeField] public int EnemyCount;
    [SerializeField] private GameObject BossSystem;
    [SerializeField] private int EnemyHP;
    public static EnemyFac Instance;
    private void Start()
    {
        Instance = this;
        StartCoroutine(Normal());
    }
    IEnumerator Normal()
    {
        while (EnemyCount >=1)
        {
            GameObject obj = PoolManager.Instance.Come("MeatBall");
            obj.GetComponent<EnemyHp>().hp = EnemyHP;
            obj.transform.position = new Vector3(Random.Range(StageData.MIn.x, StageData.Max.x), StageData.Max.y + 0.5f);
            obj.GetComponent<Enemy>().MoveStart();
            EnemyCount--;
            if(EnemyCount == 0)
            {
                BossCome();
            }
            yield return new WaitForSeconds(Random.Range(0.5f ,1f));
        }
    }

    private void BossCome()
    {
        BossSystem.SetActive(true);
    }
}
