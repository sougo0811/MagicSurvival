using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //このスクリプトの役割
    //プレイヤーとカメラの位置を一定に保つ

    private Transform player;
    [SerializeField]
    private float boundX = 0.3f, boundY = 0.15f;
    private Vector3 deltaPos;
    private float deltaX, deltaY;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (!player)
        {
            return;
        }

        deltaPos = Vector3.zero;

        deltaX = player.position.x - transform.position.x;
        deltaY = player.position.y - transform.position.y;

        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < player.position.x)
            {
                deltaPos.x = deltaX - boundX;
            }
            else
            {
                deltaPos.x = deltaX + boundX;
            }
        }

        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < player.position.y)
            {
                deltaPos.y = deltaY - boundY;
            }
            else
            {
                deltaPos.y = deltaY + boundY;
            }
        }

        deltaPos.z = 0;

        transform.position += deltaPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
