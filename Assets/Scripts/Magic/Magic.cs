using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    //このスクリプトの役割
    //弾の速度や攻撃力の管理、動く方向の設定や弾の非表示などを行う

    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 2.5f, deactiveTimer = 3f;
    [SerializeField]
    private int damageAmount = 25;
    private bool damage;
    [SerializeField]
    private bool destroyObject;
    [SerializeField]
    private bool getTrailRanderer;
    private TrailRenderer trail;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (getTrailRanderer)
        {
            trail = GetComponent<TrailRenderer>();
        }
    }


    private void OnEnable()
    {
        damage = false;

        Invoke("DeactiveMagic", deactiveTimer);

    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;

        if (getTrailRanderer)
        {
            trail.Clear();
        }
    }

    public void MoveDirection(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed;
    }

    void DeactiveMagic()
    {
        if (destroyObject)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") ||
            collision.CompareTag("Boss"))
        {
            rb.velocity = Vector2.zero;

            CancelInvoke("DeactiveMagic");

            if (!damage)
            {
                damage = true;

                collision.GetComponent<Health>().TakeDamage(damageAmount);
            }

            DeactiveMagic();
        }

        if (collision.CompareTag("Blocking"))
        {
            rb.velocity = Vector2.zero;

            CancelInvoke("DeactiveMagic");

            DeactiveMagic();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
