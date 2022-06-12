using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManagerDefenseMode : MonoBehaviour
{
    //���̃X�N���v�g�̖���
    //�����̃G�l�~�[���Ǘ�

    [SerializeField]
    public List<Movement> enemies;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (Transform tr in GetComponentInChildren<Transform>())
        {
            enemies.Add(tr.GetComponent<Movement>());
        }
    }

    public void EnablePlayerTargetDefenseMode()
    {
        foreach (Movement move in enemies)
        {
            move.HasPlayerTarget = true;
            move.HasMagiCrystalTarget = true;
        }
    }

    public void DesablePlayerTargetDefenseMode()
    {
        foreach (Movement move in enemies)
        {
            move.HasPlayerTarget = false;
            move.HasMagiCrystalTarget = false;
        }
    }
}
