using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefenseMode : Movement
{
    //このスクリプトの役割
    //追跡や攻撃などのAI部分

    //public bool Test;

    private Transform player;
    private Transform magicCrystal;
    private Vector3 playerLastPos, magicCrystalLastPos, startPos, movementPos;
    [SerializeField]
    private float chaseSpeed = 0.8f, turningDelay = 1f;
    private float lastFollowTime, turningTimeDelay = 1f;

    private Vector3 tempScale;

    private bool attacked;
    [SerializeField]
    private float damageCooldown = 1f;
    private float damageCooldownTimer;
    [SerializeField]
    private int damageAmount = 1;

    private Health enemyHealth;

    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        magicCrystal = GameObject.FindWithTag("MagicCrystal").transform;

        playerLastPos = player.position;
        magicCrystalLastPos = magicCrystal.position;
        startPos = transform.position;
        lastFollowTime = Time.time;

        //エネミーAIの追跡タイムラグ
        turningDelay *= turningDelay;

        enemyHealth = GetComponent<Health>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!enemyHealth.IsAllive() || !player || !magicCrystal)
        {
            return;
        }
        MoveAnimation();

        TurnAround();

        if (Vector3.Distance(transform.position, playerLastPos) > Vector3.Distance(transform.position, magicCrystalLastPos))
        {
            ChaseingMagicCrystal();
        }
        else
        {
            ChaseingPlayer();
        }
        
    }

    void ChaseingPlayer()
    {
        if (HasPlayerTarget)
        {
            if (!attacked)
            {
                Chase();
            }
            else
            {
                if (Time.time < damageCooldownTimer)
                {
                    movementPos = startPos - transform.position;
                }
                else
                {
                    attacked = false;
                }
            }
        }
        else
        {
            movementPos = startPos - transform.position;

            if (Vector3.Distance(transform.position, startPos) < 0.1f)
            {
                movementPos = Vector3.zero;
            }
        }

        CharacterMovement(movementPos.x, movementPos.y);
    }

    void ChaseingMagicCrystal()
    {
        if (HasMagiCrystalTarget)
        {
            if (!attacked)
            {
                Chase();
            }
            else
            {
                if (Time.time < damageCooldownTimer)
                {
                    movementPos = startPos - transform.position;
                }
                else
                {
                    attacked = false;
                }
            }
        }
        else
        {
            movementPos = startPos - transform.position;

            if (Vector3.Distance(transform.position, startPos) < 0.1f)
            {
                movementPos = Vector3.zero;
            }
        }

        CharacterMovement(movementPos.x, movementPos.y);
    }

    void Chase()
    {
        if (Time.time - lastFollowTime > turningTimeDelay)
        {
            playerLastPos = player.transform.position;
            magicCrystalLastPos = magicCrystal.transform.position;
            lastFollowTime = Time.time;
        }

        if (Vector3.Distance(transform.position, playerLastPos) > 0.15f && Vector3.Distance(transform.position, playerLastPos) < Vector3.Distance(transform.position, magicCrystalLastPos))
        {
            movementPos = (playerLastPos - transform.position).normalized * chaseSpeed;
        }
        else if (Vector3.Distance(transform.position, magicCrystalLastPos) > 0.15f)
        {
            movementPos = (magicCrystalLastPos - transform.position).normalized * chaseSpeed;
        }
        else
        {
            movementPos = Vector3.zero;
        }
    }

    void TurnAround()
    {
        tempScale = transform.localScale;

        if (HasPlayerTarget)
        {
            if (player.position.x > transform.position.x)
            {
                tempScale.x = Mathf.Abs(tempScale.x);
            }
            if (player.position.x < transform.position.x)
            {
                tempScale.x = -Mathf.Abs(tempScale.x);
            }
        }
        else if (HasMagiCrystalTarget)
        {
            if (magicCrystal.position.x > transform.position.x)
            {
                tempScale.x = Mathf.Abs(tempScale.x);
            }
            if (magicCrystal.position.x < transform.position.x)
            {
                tempScale.x = -Mathf.Abs(tempScale.x);
            }
        }
        else
        {
            if (startPos.x > transform.position.x)
            {
                tempScale.x = Mathf.Abs(tempScale.x);
            }
            if (startPos.x < transform.position.x)
            {
                tempScale.x = -Mathf.Abs(tempScale.x);
            }
        }

        transform.localScale = tempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageCooldownTimer = Time.time + damageCooldown;

            attacked = true;

            collision.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
        else if (collision.CompareTag("MagicCrystal"))
        {
            damageCooldownTimer = Time.time + damageCooldown;

            attacked = true;

            collision.GetComponent<MagicCrystalHealth>().TakeDamage(damageAmount);
        }
    }

    void MoveAnimation()
    {
        if (GetMoveDelta().sqrMagnitude > 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
