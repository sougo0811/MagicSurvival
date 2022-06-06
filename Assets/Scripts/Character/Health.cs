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
    //private int crystalHealth;
    private Animator animator;

    [SerializeField]
    private int maxMagicPoint = 10;
    public int magicPoint;
    [SerializeField]
    private float magicCoolTimer = 3f;

    private float timer;

    public SceneController sceneController;
    //public GameObject player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        magicPoint = maxMagicPoint;
    }

    private void Start()
    {
        health = maxHealth;
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
        health -= damageAmount;

        if (health <= 0)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                animator.SetTrigger("Death");

                Debug.Log(Time.timeScale);
            }
            else
            {
                
            }
            
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
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CallSceneController();
        }

    }

    public void CallSceneController()
    {
        if (health <= 0)
        {
            sceneController.ToGameOver();
            Debug.Log("Called ToGameOver");
        }
    }
}
