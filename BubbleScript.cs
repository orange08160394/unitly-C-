using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour {
    Flutter fcomp;          // Flutter 腳本元件參考變數
    GameObject bubble;	    // 氣泡物件參考變數
    public Material[] mat=new Material[6];	// 材質的陣列
	float genPeriod=0.7f;   // 產生兩顆氣泡的間隔時間(秒)
    float accKey=0.0f;      // 按鍵累計值
    void Update () {
        // 讀取水平軸向按鍵
        float x = Input.GetAxis("Horizontal");
        // 只累計往右按鍵值
        if (x > 0)   accKey += x;　　
		if (accKey >= genPeriod) {
			// 時間超過生產間隔時間，就再產生一顆氣泡
			bubble =GameObject.CreatePrimitive(PrimitiveType.Sphere);
			// 亂數隨機選種Material給氣泡
			bubble.GetComponent<Renderer>().material=mat[Random.Range(0,3)];
			// 將 Flutter.cs 程式加到氣泡做為元件，並用fcomp變數記錄腳本元件
			fcomp=bubble.AddComponent<Flutter> ();
            // 根據按鍵速度，將泡泡成長與移動速度，傳給Flutter腳本
            fcomp.speed = 0.3f + x;
			// 亂數隨機指定氣泡銷毀的時間
			Destroy (bubble, Random.Range(0.6f, 1.2f));
			// 產生一個泡泡，會消牦掉一份累計按鍵的時間
			accKey -= genPeriod;
		}
	}
}
