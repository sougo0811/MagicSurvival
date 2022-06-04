using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //このスクリプトの役割
    //全キャラの体力管理や死亡アニメーション+魔力管理

    [SerializeField]
    private int maxHealth = 5;
    private int health;
    private Animator animator;

    [SerializeField]
    private int maxMagicPoint = 10;
    public int magicPoint;
    [SerializeField]
    private float magicCoolTimer = 3f;

    private float timer;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        magicPoint = maxMagicPoint;
    }

    private void Start()
    {
        health = maxHealth;
    }

    public bool IsAllive()
    {
        return health > 0 ? true : false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= magicCoolTimer && magicPoint < maxMagicPoint)
        {
            magicPoint += 1;
            timer = 0f;

            Debug.Log(magicPoint);
        }
        
    }
}
