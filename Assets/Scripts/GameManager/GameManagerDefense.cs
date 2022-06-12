using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerDefense : MonoBehaviour
{
    [SerializeField]
    public float limitTimer = 100f;
    public float timer;

    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private MagicCrystalHealth crystalHealth;

    public SceneController sceneController;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = limitTimer.ToString("f1");
        timer = limitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer >= 0)
        {
            timerText.text = timer.ToString("f1");
        }
        else
        {
            timerText.text = "CLEAR!";
        }
        //Debug.Log(timer);

        if (!playerHealth.IsAllive())
        {
            Invoke("CalledToGameOver", 1f);
        }

        if (!crystalHealth.IsAllive())
        {
            Invoke("CalledToGameOver", 1f);
        }

        if (timer <= 0)
        {
            Invoke("CalledToGameClear", 0.5f);
        }

    }

    public void CalledToGameClear()
    {
        sceneController.ToGameClear();
    }

    public void CalledToGameOver()
    {
        sceneController.ToGameOver();
    }
}
