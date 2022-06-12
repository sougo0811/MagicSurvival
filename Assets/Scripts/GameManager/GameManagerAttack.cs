using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAttack : MonoBehaviour
{
    GameObject[] tagObjects;

    [SerializeField]
    public float interval = 3.0f;
    public float timer = 0.0f;

    [SerializeField]
    private PlayerHealth playerHealth;

    public SceneController sceneController;

    public Text enemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        enemyCountText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            EnemyCheck("Enemy");
            timer = 0.0f;
        }

        if (!playerHealth.IsAllive())
        {
            Invoke("CalledToGameOver", 1f);
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

    public void EnemyCheck(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        enemyCountText.text = tagObjects.Length.ToString();
        if (tagObjects.Length == 0)
        {
            Invoke("CalledToGameClear", 0.5f);
        }
    }
}
