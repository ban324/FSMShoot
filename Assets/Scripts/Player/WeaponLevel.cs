using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLevel : MonoBehaviour
{
    [SerializeField] int LevelCount;
    [SerializeField] int Score;
    [SerializeField] int Level;
    public int levelCount
    {
        get { return LevelCount; }
        set { LevelCount = value; }
    }
    public static WeaponLevel Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        CheckWeapon();  
        if(Level == 1)
        {
            GameObject.Find("FirePos1").GetComponent<Fire>().delay = 0.2f;
            GameObject.Find("FirePos2").GetComponent<Fire>().delay = 0.2f;
        }
        if (Level == 2)
        {
            GameObject.Find("Player").GetComponent<PMoving>().Level3 = true;
        }
        if(Level == 3)
        {
            GameObject.Find("Player").GetComponent<PMoving>().delay = 0.2f;
        }

    }

    public void GetScore(int score)
    {
        Score += score;
    }
    public void GetExp(int Exp)
    {
        LevelCount += Exp;
    }
    void CheckWeapon()
    {

        if (levelCount >= 500)
        {
            Level = 3;
        }
        else if (levelCount >= 300)
        {
            Level = 2;
        }
        else if (levelCount >= 100)
        {
            Level = 1;
        }
    }
}
