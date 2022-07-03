using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    public GameObject poolObject;
    public Poolable obj;
    Stack<Poolable> poolStack = new Stack<Poolable>();
    public void init(Poolable poolobj, int count = 5)
    {
        poolObject = poolobj.gameObject;
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate<GameObject>(poolObject);
            obj.name = poolObject.name;
            obj.SetActive(false);
            poolStack.Push(obj.GetComponent<Poolable>());

        }
    }
    public Poolable Pop()
    {
        if (poolStack.Count > 0)
        {
            obj = poolStack.Pop();
            if(obj != null)obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate(poolObject).GetComponent<Poolable>();
            obj.name = poolObject.name;
        }
        return obj;
    }
    public void push(Poolable obj)
    {
        poolStack.Push(obj);
        obj.gameObject.SetActive(false);
    }
}