using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyTargetAttackMode
{
    EnableTargetAttackMode,
    DisableTargetAttackMode
}

public class EnemyRoomAttackMode : MonoBehaviour
{
    //�v���C���[�̓��ޏ�����m����

    [SerializeField]
    private EnemyTargetAttackMode enemyTarget;

    [SerializeField]
    private EnemyRoomManagerAttackMode enemyRoomManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enemyTarget == EnemyTargetAttackMode.EnableTargetAttackMode)
            {
                enemyRoomManager.EnablePlayerTargetAttackMode();
            }
            else
            {
                enemyRoomManager.DesablePlayerTargetAttackMode();
            }
        }
    }
}
