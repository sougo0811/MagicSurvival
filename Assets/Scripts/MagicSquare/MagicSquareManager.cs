using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareManager : MonoBehaviour
{
    //このスクリプトは、playerの向いている方向に合わせて表示する魔方陣を切り替えるスクリプト


    [SerializeField]
    private GameObject[] magicSquares;
    private int currentMagicSquare;

    // Start is called before the first frame update
    private void Start()
    {
        DeactiveateAllMagicSquares();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeactiveateAllMagicSquares()
    {
        for(int i = 0; i < magicSquares.Length; i++)
        {
            magicSquares[i].SetActive(false);
        }
    }

    public void ActivateMagicSquare(int newMagicSquare)
    {
        magicSquares[currentMagicSquare].SetActive(false);

        currentMagicSquare = newMagicSquare;

        magicSquares[currentMagicSquare].SetActive(true);
    }
}
