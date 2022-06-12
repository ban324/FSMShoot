using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMoving : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float Sspeed;
    [SerializeField]
    private Rigidbody2D Rigid2d;

    // Update is called once per frame
    void Update()
    {
        SpeedChange();
        Move();
        Correction();

    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Rigid2d.velocity = new Vector2(x, y) * speed;
    }
    void SpeedChange()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = Sspeed;
        }
        else
        {
            speed = Sspeed * 2;
        }
    }
    void Correction()
    {
        float x = Mathf.Clamp(transform.position.x, stageData.MIn.x, stageData.Max.x);
        float y = Mathf.Clamp(transform.position.y, stageData.MIn.y, stageData.Max.y);
        transform.position = new Vector3(x, y);
    }
    

}
