using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    //このスクリプトは移動やアニメーション、キャラの向きなどを管理する

    private float moveX, moveY;

    private Camera mainCam;
    private Vector2 mousePos, direction;
    private Vector3 tempScale;
    private Animator animator;

    private PlayerMagicSquareManager playerMagicSquareManager;


    private void Awake()
    {
        mainCam = Camera.main;
        animator = GetComponent<Animator>();

        playerMagicSquareManager = GetComponent<PlayerMagicSquareManager>();
    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        PlayerTurning();

        CharacterMovement(moveX,moveY);

    }

    void PlayerTurning()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        PlayerAnimation(direction.x, direction.y);
    }

    void PlayerAnimation(float x, float y)
    {
        //10.5なら10 11.5なら12に丸める
        x = Mathf.RoundToInt(x);
        y = Mathf.RoundToInt(y);

        tempScale = transform.localScale;
        if(x > 0)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else if(x < 0)
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }

        transform.localScale = tempScale;

        x = Mathf.Abs(x);
        animator.SetFloat("FaceX", x);
        animator.SetFloat("FaceY", y);

        DirectionMagicSquare(x, y);
    }

    void DirectionMagicSquare(float x, float y)
    {
        //Side
        if (x == 1f && y == 0f)
        {
            playerMagicSquareManager.Activate(0);
        }
        //Up
        if (x == 0f && y == 1f)
        {
            playerMagicSquareManager.Activate(1);
        }
        //Flont
        if (x == 0f && y == -1f)
        {
            playerMagicSquareManager.Activate(2);
        }
        //Side_Up
        if (x == 1f && y == 1f)
        {
            playerMagicSquareManager.Activate(3);
        }
        //Side_Down
        if (x == 1f && y == -1f)
        {
            playerMagicSquareManager.Activate(4);
        }
    }
}
