# unitly-C-
```C#
some C#script for unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinRotation : MonoBehaviour {
    float myTheda;          // 目前指針的角度
    float prevChange;       // 上一個 frame 的變化量
    float sens = 0.05f;     // 靈敏度(0.0~1.0)，值愈大愈靈敏
    float inertia = 0.95f;  // 慣性係數(0.0~1.0)，值愈大慣性愈大

    void Start()
    {   // 原先指針角度
        myTheda = 0.0f;
    }

    void Update()
    {   // 取得 parent (碟盤)腳本中的角度 theda
        float parentTheda
            = GetComponentInParent<CompassMoving>().theda;
        // 準備指針的新角度
        float newTheda;
        // 方法1: 根據碟盤角度，直接旋轉指針到最後的位置
        // newTheda = - parentTheda;
        // 方法2: 將計算的最後角度，跟前一次的角度平均一下，目的是想讓它慢一點轉到最後角度，但效果不明顯
        // newTheda = (myTheda - parentTheda)/2.0f;
        // 方法3: 使用加權平均值，sens 愈大愈快趨近計算出的最後角度
        // newTheda = myTheda * (1-sens) - parentTheda * sens;	
        // 方法4: 同方法3，然後加上前一次的旋轉角度乘上一個inertia加權值，當做慣性
        newTheda = myTheda * (1 - sens) - parentTheda * sens + prevChange * inertia; 
        // 記錄本次變化，給下一個 frame 做為 prevChange                                      
        prevChange = newTheda - myTheda;
        myTheda = newTheda;
        // 設定指針的 local 角度為 myTheda
        transform.localRotation = Quaternion.Euler(0.0f, myTheda, 0.0f);
    }
}
```
