using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCrystalHealth : MonoBehaviour
{
    //���̃X�N���v�g�̖���
    //�v���C���[�̗̑͊Ǘ��⎀�S�A�j���[�V����+���͊Ǘ�

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

    public PlayerHealth playerHealth;

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
        if (health > playerHealth.health)
        {
            health = playerHealth.health;
        }
        else
        {
            playerHealth.health = health;
        }
        health -= damageAmount;
        if (health <= 0)
        {
            if (GameObject.FindGameObjectWithTag("MagicCrystal"))
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
