using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float interval;
    private float timer;

    public GameObject[] enemyPrefab;
    public int whichEnemy;

    private Transform myTransform;

    [SerializeField]
    Transform characterParent;

    public EnemyRoomManagerDefenseMode enemyRoomManagerDefense;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        interval = 0f;
        interval = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            int whichEnemy = Random.Range(0, 4);
            GameObject enemy = Instantiate(enemyPrefab[whichEnemy], Vector3.zero, Quaternion.identity, characterParent);
            enemy.transform.position = new Vector3(myTransform.position.x, myTransform.position.y+1, 0);
            enemyRoomManagerDefense.enemies.Add(enemy.GetComponent<Movement>());
            interval = Random.Range(5, 16);
            timer = 0f;
        }
    }
}
