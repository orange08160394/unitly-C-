using UnityEngine;

public class FinishZone : MonoBehaviour
{
    // public變數會出現在Inspector，以便連結(代入實際參數)
    public GameManager gameManager;

    // 當Player到達目的地時(撞到目的地的collider)
    // 就呼叫 gameManager裡面的 FinishedGame() 函數
    void OnTriggerEnter(Collider other)
    {
        gameManager.FinishedGame();
    }
}
