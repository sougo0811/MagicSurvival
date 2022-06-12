using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManagerAttackMode : MonoBehaviour
{
    //このスクリプトの役割
    //部屋のエネミーを管理

    [SerializeField]
    private List<Movement> enemies;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (Transform tr in GetComponentInChildren<Transform>())
        {
            enemies.Add(tr.GetComponent<Movement>());
        }
    }

    public void EnablePlayerTargetAttackMode()
    {
        foreach (Movement move in enemies)
        {
            move.HasPlayerTarget = true;
        }
    }

    public void DesablePlayerTargetAttackMode()
    {
        foreach (Movement move in enemies)
        {
            move.HasPlayerTarget = false;
        }
    }
}
