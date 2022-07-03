using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SP;
    // Start is called before the first frame update
    public void OnActive()
    {
        SP = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }
    public void OnFalsed()
    {
        StopAllCoroutines();
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            SP.color = Color.yellow;
            yield return new WaitForSeconds(0.1f);
            SP.color = Color.white;
        }
    }

}
