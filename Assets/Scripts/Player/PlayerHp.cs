using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject player;
    [SerializeField] private int Zanki;
    static public PlayerHp Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void OnDie(GameObject Player)
    {
        StartCoroutine(Die(Player));
        Zanki--;

    }
    IEnumerator Die(GameObject Player)
    {
        ParticleSystem particle = Instantiate(explosion);
        particle.Play();
        particle.transform.position = Player.transform.position;
        Player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Player.SetActive(true);
        Player.transform.position = new Vector3(0, -3.5f);
    }
}
