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
    private float Delay = 0.5f;
    public bool Level3 = false;
    [SerializeField] private GameObject Bull;
    public float delay
    {
        get { return Delay; }
        set { Delay = value; }
    }

    public bool OnShoot { get; private set; }
    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        SpeedChange();
        Move();
        Correction();
        PowerShot();
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
            GameObject.Find("FirePos1").transform.position = transform.position + new Vector3(-0.2f, 0.3f);
            GameObject.Find("FirePos2").transform.position = transform.position + new Vector3(0.2f, 0.3f);
            speed = Sspeed;
        }
        else
        {
            speed = Sspeed * 2;
            GameObject.Find("FirePos1").transform.position = transform.position + new Vector3(-0.6f, 0);
            GameObject.Find("FirePos2").transform.position = transform.position + new Vector3(0.6f, 0);
        }
    }
    void Correction()
    {
        float x = Mathf.Clamp(transform.position.x, stageData.MIn.x, stageData.Max.x);
        float y = Mathf.Clamp(transform.position.y, stageData.MIn.y, stageData.Max.y);
        transform.position = new Vector3(x, y);
    }

    public void PowerShot()
    {
        if (Level3)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(Firing());
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                StopAllCoroutines();
            }
        }
    }
    IEnumerator Firing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);

            
                GameObject obj = PoolManager.Instance.Come("Bullet");
                obj.transform.position = transform.position;
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EBullet"))
        {
            PlayerHp.Instance.OnDie(gameObject);
        }
    }



}
