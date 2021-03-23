using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
	// public 變數用來連結其他件
	public GameManager gameManager; 

	// 當Player失足落水時
	void OnTriggerEnter(Collider other)
	{
        Debug.Log("Fall");
		// 將Player瞬移回誕生地
		gameManager.PositionPlayer();
	}
}
