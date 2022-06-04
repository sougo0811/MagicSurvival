using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //このスクリプトの役割
    //射撃時にカメラをランダムに揺らす

    [SerializeField]
    private float shakeAmount = 0.007f;
    private Vector3 camPos;
    private float cameraShakingOffset_X, cameraShakingOffset_Y;


    public void ShakeCamera(float shaketime)
    {
        InvokeRepeating("StartCameraShaking", 0f, 0.01f);

        Invoke("StopCameraShaking", shaketime);
    }

    void  StartCameraShaking()
    {
        if (shakeAmount > 0)
        {
            camPos = transform.position;

            cameraShakingOffset_X = Random.value * shakeAmount * 2 - shakeAmount;
            cameraShakingOffset_Y = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += cameraShakingOffset_X;
            camPos.y += cameraShakingOffset_Y;

            transform.position = camPos;
        }
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");

        transform.localPosition = Vector3.zero;
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
