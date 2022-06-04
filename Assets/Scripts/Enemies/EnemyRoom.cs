using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTarget
{
    EnableTarget,
    DisableTarget
}

public class EnemyRoom : MonoBehaviour
{
    //プレイヤーの入退場を検知する

    [SerializeField]
    private EnemyTarget enemyTarget;

    [SerializeField]
    private EnemyRoomManager enemyRoomManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enemyTarget == EnemyTarget.EnableTarget)
            {
                enemyRoomManager.EnablePlayerTarget();
            }
            else
            {
                enemyRoomManager.DesablePlayerTarget();
            }
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
