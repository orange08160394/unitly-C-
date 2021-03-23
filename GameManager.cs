using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{	
	// public�ܼƥΨӻP��L����s��
	public Transform spawnPoint;
	public GameObject player;
    public FirstPersonController fpc;

	// �O���C����e���A���X��
	private float elapsedTime = 0;      // �C���B��ɶ��֭p
	private bool isRunning = false;     // �C���O�_���b�B��
	private bool isFinished = false;    // �C���O�_�w�g����

	// �O���Ĥ@�H�٥D���������2�ӰѦ��ܼ�
	private FirstPersonController fpsController;
    private CharacterController charController;

	void Start ()
	{
        // ��X�åB�O���Ĥ@�H�٥D����2�ӱ���ðO����
        charController = player.GetComponent<CharacterController>();
        fpsController = player.GetComponent<FirstPersonController> ();

        // ���Ȯ�����2�ӱ��
        charController.enabled = false;
        fpsController.enabled = false;
	}

	// �C���}�l���B�z
	private void StartGame()
	{
		elapsedTime = 0;
		isRunning = true;
		isFinished = false;

        // �NPlayer������ϥͦa
        PositionPlayer();
        // �_�ʲĤ@�H�٥D�������
        charController.enabled = true;
        fpsController.enabled = true;
    }


    void Update ()
	{
		// �֭p�{���B��ɶ�
		if (isRunning)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
		}

    }


    // �C�����`�}�l�A�D���^��ϥͦa
    public void PositionPlayer()
	{   // ������2�ӱ��
        charController.enabled = false;
        fpsController.enabled = false;
        // �Ĥ@�H�٨���^��_�I
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        // �A�Ұ�2�ӱ��
        charController.enabled = true;
        fpsController.enabled = true;
    }


    // �D���w�g��F���I���B�z
    public void FinishedGame()
	{
		isRunning = false;
		isFinished = true;
        charController.enabled = false;
        fpsController.enabled = false;
	}
	
	
	// �z�L�ϥΪ̤���(GUI)��ܰT��
	void OnGUI() {
		
		if(!isRunning)
		{
			string message;

			if(isFinished)
			{
				message = "���UEnter���s�}�l";
			}
			else
			{
				message = "���UEnter�}�l�C��";
			}

			// Define a new rectangle for the UI on the screen
			Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2, 240, 30);

			if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
			{
                // �C���}�l
                StartGame();
			}
		}
		
		if(isFinished)
        {   // �C����������ܪ�O�ɶ�
            GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "�F�����ȶO��: ");
			GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)elapsedTime).ToString());
		}
		else if(isRunning)
		{ 
			// �C���i�椤, ��ܥثe�֭p�ɶ�
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "�ثe�֭p�ɶ�");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
		}
	}
}
