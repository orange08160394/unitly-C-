using UnityEngine;

public class FinishZone : MonoBehaviour
{
    // public�ܼƷ|�X�{�bInspector�A�H�K�s��(�N�J��ڰѼ�)
    public GameManager gameManager;

    // ��Player��F�ت��a��(����ت��a��collider)
    // �N�I�s gameManager�̭��� FinishedGame() ���
    void OnTriggerEnter(Collider other)
    {
        gameManager.FinishedGame();
    }
}
