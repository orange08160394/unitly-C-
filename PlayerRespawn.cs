using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
	// public �ܼƥΨӳs����L��
	public GameManager gameManager; 

	// ��Player����������
	void OnTriggerEnter(Collider other)
	{
        Debug.Log("Fall");
		// �NPlayer�����^�ϥͦa
		gameManager.PositionPlayer();
	}
}
