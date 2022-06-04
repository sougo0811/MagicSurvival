using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public float limitTimer = 30f;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = limitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Debug.Log(timer);
    }
}
