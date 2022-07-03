using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject player;
    [SerializeField] private int Zanki;
    [SerializeField] private GameObject Zan1;
    [SerializeField] private GameObject Zan2;
    static public PlayerHp Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void OnDie(GameObject Player)
    {
        StartCoroutine(Die(Player));

    }
    IEnumerator Die(GameObject Player)
    {
        ParticleSystem particle = Instantiate(explosion);
        particle.Play();
        particle.transform.position = Player.transform.position;
        Player.gameObject.SetActive(false);
        Player.GetComponent<CircleCollider2D>().enabled = false;
        Zanki--;
        yield return new WaitForSeconds(1f);
        if (Zanki < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        Player.transform.position = new Vector3(0, -3.5f);
        Player.SetActive(true);
        yield return new WaitForSeconds(2f);
        Player.GetComponent<CircleCollider2D>().enabled = true;
    }
    private void Update()
    {
        if(Zanki == 2)
        {
            Zan1.SetActive(true);
            Zan2.SetActive(true);
        }
        if(Zanki == 1)
        {
            Zan1.SetActive(false);
            Zan2.SetActive(true);
        }
        if(Zanki == 0)
        {
            Zan1.SetActive(false);
            Zan2.SetActive(false);

        }

    }
}
