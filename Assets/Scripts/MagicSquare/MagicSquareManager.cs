using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareManager : MonoBehaviour
{
    //���̃X�N���v�g�́Aplayer�̌����Ă�������ɍ��킹�ĕ\�����閂���w��؂�ւ���X�N���v�g


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
