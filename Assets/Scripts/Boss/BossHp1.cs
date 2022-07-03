using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHp1 : MonoBehaviour
{
    [SerializeField] private float MaxHp;
    [SerializeField] Slider HPbar;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] private float CurrentHp;
    [SerializeField] private GameObject Clear;
    bool ondie = false;
    public string nextStage;
    public float HP
    {
        get => CurrentHp;
        set => CurrentHp = value;
    }
    public void BarOn()
    {
        HPbar.gameObject.SetActive(true);
    }

    public void OnDamage(float Damage)
    {
        if (CurrentHp <= 0)
        {
            ondie = true;
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
            OnDie();
        }
        else if(ondie == false)
        {
            CurrentHp -= Damage;
            HPbar.value = CurrentHp / MaxHp;
        }
    }
    public void OnDie()
    {
        GetComponent<Boss2Attack>().StopAllCoroutines();
        Destroy(GetComponent<Boss2Attack>());
        HPbar.gameObject.SetActive(false);
        
        StartCoroutine(Diying());
    }

    IEnumerator Diying()
    {
        Vector3 onrae = transform.position;
        while(sprite.color.a >= 0)
        {
            transform.position = onrae + new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f));
            sprite.color -= new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        PlayerPrefs.SetInt("GScore", PlayerPrefs.GetInt("GScore", 0)+Score.instance.score);
        Clear.SetActive(true);
    }
}
