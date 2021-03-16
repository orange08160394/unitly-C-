using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour { 
    GameObject enemy;
    void Start()
    {   // 先根據 tag "Enemy" 找場景中的物件
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

   void Update()
    {   // 讓方向指引對準 NPC 物件
        transform.LookAt(enemy.transform);
    }
}
