using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{	
	// public變數用來與其他物件連結
	public Transform spawnPoint;
	public GameObject player;
    public FirstPersonController fpc;

	// 記錄遊戲當前狀態的旗號
	private float elapsedTime = 0;      // 遊戲運行時間累計
	private bool isRunning = false;     // 遊戲是否正在運行
	private bool isFinished = false;    // 遊戲是否已經結束

	// 記錄第一人稱主角控制器元件的2個參考變數
	private FirstPersonController fpsController;
    private CharacterController charController;

	void Start ()
	{
        // 找出並且記錄第一人稱主角的2個控制器並記錄之
        charController = player.GetComponent<CharacterController>();
        fpsController = player.GetComponent<FirstPersonController> ();

        // 先暫時關掉2個控制器
        charController.enabled = false;
        fpsController.enabled = false;
	}

	// 遊戲開始的處理
	private void StartGame()
	{
		elapsedTime = 0;
		isRunning = true;
		isFinished = false;

        // 將Player瞬移到誕生地
        PositionPlayer();
        // 起動第一人稱主角的控制器
        charController.enabled = true;
        fpsController.enabled = true;
    }


    void Update ()
	{
		// 累計程式運行時間
		if (isRunning)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
		}

    }


    // 遊戲重訢開始，主角回到誕生地
    public void PositionPlayer()
	{   // 先關掉2個控制器
        charController.enabled = false;
        fpsController.enabled = false;
        // 第一人稱角色回到起點
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        // 再啟動2個控制器
        charController.enabled = true;
        fpsController.enabled = true;
    }


    // 主角已經抵達終點的處理
    public void FinishedGame()
	{
		isRunning = false;
		isFinished = true;
        charController.enabled = false;
        fpsController.enabled = false;
	}
	
	
	// 透過使用者介面(GUI)顯示訊息
	void OnGUI() {
		
		if(!isRunning)
		{
			string message;

			if(isFinished)
			{
				message = "按下Enter重新開始";
			}
			else
			{
				message = "按下Enter開始遊戲";
			}

			// Define a new rectangle for the UI on the screen
			Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2, 240, 30);

			if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
			{
                // 遊戲開始
                StartGame();
			}
		}
		
		if(isFinished)
        {   // 遊戲完成的顯示花費時間
            GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "達成任務費時: ");
			GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)elapsedTime).ToString());
		}
		else if(isRunning)
		{ 
			// 遊戲進行中, 顯示目前累計時間
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "目前累計時間");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
		}
	}
}
