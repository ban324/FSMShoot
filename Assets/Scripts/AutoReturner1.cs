using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReturner1 : MonoBehaviour
{
    [SerializeField] StageData stageData;
    private void Update()
    {
        if(transform.position.y >= stageData.Max.y+5 || transform.position.y <= stageData.MIn.y-5 || transform.position.x >= stageData.Max.x +5|| transform.position.x <= stageData.MIn.x-5)
        {
            if (gameObject.CompareTag("EBullet"))
            {
                GetComponent<EBullet>().dir = Vector3.zero;
            }
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
    }
}
