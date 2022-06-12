using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //このスクリプトはBoss以外の全てのキャラの移動を扱う(PlayerもEnemyも)

    [SerializeField]
    protected float xSpeed = 1.5f, ySpeed = 1.5f;
    private Vector2 moveDelta;

    private bool _hasPlayerTarget;
    private bool _hasMagicCrystalTarget;
    public bool HasPlayerTarget
    {
        get { return _hasPlayerTarget; }
        set { _hasPlayerTarget = value; }
    }
    public bool HasMagiCrystalTarget
    {
        get { return _hasMagicCrystalTarget; }
        set { _hasMagicCrystalTarget = value; }
    }

    protected void CharacterMovement(float x, float y)
    {
        moveDelta = new Vector2(x * xSpeed, y * ySpeed);

        transform.Translate(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime, 0);
    }

    public Vector2 GetMoveDelta()
    {
        return moveDelta;
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
