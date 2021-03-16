using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	void Update () {
        // 根據鍵盤左右按鍵(水平移位)來旋轉
		transform.Rotate(0,Input.GetAxis ("Horizontal"),0);
        // 根據鍵盤上下按鍵(垂直移位)來前進/後退
        transform.position+=transform.forward*Input.GetAxis("Vertical");
	}
}
