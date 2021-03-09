using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    // Start is called before the first frame update
    float angle; // 記錄物件目前的角度 
    void Start()
    {
        angle = 0.0f; // 設定物件最初角度設為 0 度
    }

    // Update is called once per frame
    void Update()
    {
        float d = Input.GetAxis("Mouse X"); // 讀取滑鼠左右移動的距離 
        angle += d; // 計算旋轉後的新角度 
        transform.rotation=Quaternion.Euler(0,angle,0); // 以三個各別的旋轉角度，使用 Quaternion.Eular函數， // 來產生rotation需要的Quaternion資料
    }
}
