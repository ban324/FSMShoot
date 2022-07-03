using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int Shootdown = 0;   
    public int score = 0;

    [SerializeField] private TextMeshProUGUI GeneralT;
    [SerializeField] private TextMeshProUGUI RemainT;
    [SerializeField] private TextMeshProUGUI ShootT;
    [SerializeField] private TextMeshProUGUI ScoreT;
    [SerializeField] private TextMeshProUGUI WeaponT;
    static public Score instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private GameObject EnemyF;
    private void Update()
    {
        score = Shootdown * 10 + WeaponLevel.Instance.levelCount;
        GeneralT.text = $"General\nScore\n{PlayerPrefs.GetInt("GScore")}";
        RemainT.text = $"Ramaining\nEnemies\n{EnemyF.GetComponent<EnemyFac>().EnemyCount}";
        ShootT.text = $"Shoot Down\nCount{Shootdown}";
        ScoreT.text = $"Score\n{score}";
        if(WeaponLevel.Instance.levelCount >= 150)
        {
            WeaponT.text = $"Weapon\nLevel\nMax";
        }
        else
        {
            WeaponT.text = $"Weapon\nLevel\n{WeaponLevel.Instance.levelCount}";
        }
    }
}
