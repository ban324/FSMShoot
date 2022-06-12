using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject PoolObj;
    [SerializeField] GameObject PoolObj2;
    [SerializeField] int PoolCount;
    [SerializeField] List<GameObject> PoolList;
    [SerializeField] List<GameObject> PoolList2;
    private void Awake()
    {
        for(int i = 0; i< PoolCount; i++)
        {
            GameObject obj = Instantiate(PoolObj);
            PoolList.Add(obj);
            obj.SetActive(false);
        }
        if(PoolObj2 != null)
        {
            for (int i = 0; i < PoolCount; i++)
            {
                GameObject obj2 = Instantiate(PoolObj2);
                PoolList2.Add(obj2);
                obj2.SetActive(false);
            }

        }
    }
    public void ComeOn(Vector3 pos)
    {
        if (PoolList.Count != 0)
        {
            PoolList[0].transform.position = pos;
            PoolList[0].SetActive(true);
            PoolList.RemoveAt(0);
        }
        else
        {
            GameObject obj = Instantiate(PoolObj);
            obj.transform.position = pos;
        }
    }
    public void ComeOn2(Vector3 pos)
    {
        if (PoolList.Count != 0)
        {
            PoolList2[0].transform.position = pos;
            PoolList2[0].SetActive(true);
            PoolList2.RemoveAt(0);
        }
        else
        {
            GameObject obj = Instantiate(PoolObj);
            obj.transform.position = pos;
        }
    }
    
    public void Returner(GameObject obj)
    {
        PoolList.Add(obj);
        obj.SetActive(false);
    }
}
