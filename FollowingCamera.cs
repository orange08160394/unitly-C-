using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {
    public GameObject target;
    void Update()
    {
        // Camera跟隨碟盤的後面2公尺
        Vector3 pos = target.transform.position - target.transform.forward * 2.0f;
        // 將camera 調高3公尺
        pos.y += 3.0f;
        // 設定camera到計算好皂位置
        transform.position = pos;
        // camera瞄準target拍攝
        transform.LookAt(target.transform.position);
    }
}

