using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManager : MonoBehaviour
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

    public void EnablePlayerTarget()
    {
        foreach(Movement move in enemies)
        {
            move.HasPlayerTarget = true;
        }
    }

    public void DesablePlayerTarget()
    {
        foreach (Movement move in enemies)
        {
            move.HasPlayerTarget = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
