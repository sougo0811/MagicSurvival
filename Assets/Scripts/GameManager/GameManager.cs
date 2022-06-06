using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public float limitTimer = 10f;
    public float timer;

    [SerializeField]
    private Health playerHealth,magicCrystalHealth;

    public SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        timer = limitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (!playerHealth.IsAllive())
        {
            Invoke("CalledToGameOver", 1f);
        }

        if (!magicCrystalHealth.IsAllive())
        {
            Invoke("CalledToGameOver", 1f);
        }

        if (timer <= 0)
        {
            Invoke("CalledToGameClear", 1f);
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
