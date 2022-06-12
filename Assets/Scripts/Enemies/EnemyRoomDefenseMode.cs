using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTargetDefenseMode
{
    EnableTargetDefenseMode,
    DisableTargetDefenseMode
}

public class EnemyRoomDefenseMode : MonoBehaviour
{
    //�v���C���[�̓��ޏ�����m����

    [SerializeField]
    private EnemyTargetDefenseMode enemyTarget;

    [SerializeField]
    private EnemyRoomManagerDefenseMode enemyRoomManager;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("MagicCrystal"))
        {
            if (enemyTarget == EnemyTargetDefenseMode.EnableTargetDefenseMode)
            {
                enemyRoomManager.EnablePlayerTargetDefenseMode();
            }
            else
            {
                enemyRoomManager.DesablePlayerTargetDefenseMode();
            }
        }
    }
}
