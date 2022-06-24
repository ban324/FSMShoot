using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReturner2 : MonoBehaviour
{
    [SerializeField] StageData stageData;
    private void Update()
    {
        if(transform.position.y > stageData.Max.y+1 || transform.position.y < stageData.MIn.y-1 || transform.position.x > stageData.Max.x +1|| transform.position.x < stageData.MIn.x-1)
        {
            PoolManager.Instance.Pushing(gameObject.name, gameObject);
        }
    }
}
