using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //このスクリプトの役割
    //プレイヤーの体力管理や死亡アニメーション+魔力管理

    [SerializeField]
    private int maxHealth = 10;
    public int health;
    //private int crystalHealth;
    private Animator animator;

    [SerializeField]
    private int maxMagicPoint = 10;
    public int magicPoint;
    [SerializeField]
    private float magicCoolTimer = 1f;

    private float timer;

    public Slider hpSlider;
    public Slider mpSlider;

    public SceneController sceneController;

    public MagicCrystalHealth crystalHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        health = maxHealth;
        magicPoint = maxMagicPoint;
        hpSlider.value = 1;
        mpSlider.value = 1;

        //crystalHealth = maxHealth;
        //player = GameObject.FindGameObjectWithTag("Player");
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
        if (health > crystalHealth.health)
        {
            health = crystalHealth.health;
        }
        else
        {
            crystalHealth.health = health;
        }
        health -= damageAmount;
        if (health <= 0)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                animator.SetTrigger("Death");
            }

        }
        hpSlider.value = (float)health / maxHealth;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= magicCoolTimer && magicPoint < maxMagicPoint)
        {
            magicPoint += 1;
            timer = 0f;
        }
        mpSlider.value = (float)magicPoint / maxMagicPoint;
        //Debug.Log(mpSlider.value);
    }
}
