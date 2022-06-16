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
    PoolManager poolManager;
    public bool Level3 = false;
    public float delay
    {
        get { return Delay; }
        set { Delay = value; }
    }

    public bool OnShoot { get; private set; }
    private void Awake()
    {
        poolManager = GetComponent<PoolManager>();
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
            if (OnShoot)
            {
                poolManager.ComeOn2(transform.position);
            }
            yield return new WaitForSeconds(Delay);
            poolManager.ComeOn2(transform.position);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            PlayerHp.Instance.OnDie(gameObject);
        }
    }



}
