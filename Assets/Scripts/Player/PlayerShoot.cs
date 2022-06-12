using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //このスクリプトの役割
    //プレイヤーの射撃キーの入力検知、射撃間隔設定

    [SerializeField]
    private float shootTimer, shootTimeDelay = 0.2f;

    [SerializeField]
    private Transform magicSpawnPos;
    private PlayerMagicSquareManager playerMagicSquareManager;

    public PlayerHealth playerHealth;
    public int magicPoint;

    [SerializeField]
    private bool defenseModeflg;

    private void Awake()
    {
        playerMagicSquareManager = GetComponent<PlayerMagicSquareManager>();
    }

    

    void Shooting()
    {
        if(Input.GetMouseButtonDown(0) && magicPoint > 0)
        {
            if (Time.time > shootTimer)
            {
                shootTimer = Time.time + shootTimeDelay;

                playerMagicSquareManager.Shoot(magicSpawnPos.position);

                magicPoint -= 1;

                playerHealth.magicPoint = magicPoint;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        magicPoint = playerHealth.magicPoint;
        Debug.Log(playerHealth.magicPoint);
    }

    // Update is called once per frame
     private void Update()
    {
        magicPoint = playerHealth.magicPoint;
        Shooting();
        
    }
}
