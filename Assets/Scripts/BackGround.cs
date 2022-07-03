using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private MeshRenderer rend;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 3;
        if(transform.position.y <= -10)
        {
            transform.position = new Vector3(0, 10);
        }
    }
}
