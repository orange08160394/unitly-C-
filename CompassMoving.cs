using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassMoving : MonoBehaviour
{
    public float theda; // 記錄碟盤目前的角度，將來指針角度會讀取此值做反向旋轉
    void Start()
    {
        theda = 0.0f;
    }

    void Update()
    {
        // 鍵盤的水平移動用來控制碟盤旋轉
        float dy = Input.GetAxis("Horizontal");
        theda += dy;
        transform.rotation = Quaternion.Euler(0.0f, theda, 0.0f);
        // 鍵盤的重直移動用來控制碟盤前進與後退
        float dz = Input.GetAxis("Vertical");
        transform .Translate(transform.forward * dz);
    }
}

