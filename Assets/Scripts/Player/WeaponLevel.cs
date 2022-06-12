using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLevel : MonoBehaviour
{
    [SerializeField] int LevelCount;
    public int levelCount
    {
        get { return LevelCount; }
        set { LevelCount = value; }
    }
    [SerializeField] int Level;
    public static WeaponLevel Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(levelCount >= 30)
        {
            Level = 3;
        }else if (levelCount >= 10)
        {
            Level = 2;
        }else if(levelCount >= 5)
        {
            Level = 1;
        }
        
    }
    public void GetExp(int Exp)
    {
        LevelCount += Exp;
    }
}
