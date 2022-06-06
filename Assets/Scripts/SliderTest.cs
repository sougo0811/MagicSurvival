using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    public float timer;
    public float maxTime = 100f;
    [SerializeField]
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        slider.value = timer / maxTime;
    }
}
