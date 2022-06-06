using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Opening")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToMain();
            }
        }

        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToMain();
            }
        }

        if (SceneManager.GetActiveScene().name == "GameClear")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToOpening();
            }
        }
    }

    public void ToOpening()
    {
        SceneManager.LoadScene("Opening");
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ToGameClear()
    {
        SceneManager.LoadScene("GameClear");
    }
}
