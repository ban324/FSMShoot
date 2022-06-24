using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private MeshRenderer rend;
    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(0, Random.Range(Time.deltaTime * -1, Time.deltaTime));
    }
}
