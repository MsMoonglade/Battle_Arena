using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;

    [HideInInspector]
    public float[] Score;

	public float timerSecond;
	public float timerMinute;

    public string[] battleThemesName;
    public string countdown;

    int musicSelector;

    private CharacterSelection characterSel;
    private GameObject[] players;


    public UILabel timeSecondLabel;
	public UILabel timeMinuteLabel;

	public GameObject rewiredInputControllerPrefab;
	private GameObject rewiredInputController;
	
	public GameObject pauseMenu;
    void Awake()
    {
		Time.timeScale = 1.0f;

        if (timerSecond == 0 && timerMinute == 0)
        {
            timerSecond = PlayerPrefs.GetFloat("second");
            timerMinute = PlayerPrefs.GetFloat("minute");
        }

        /*if (instance != null)
		{
			
			if (instance != this)
				Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}

		DontDestroyOnLoad (transform.gameObject);*/

        instance = this;

        characterSel = GameObject.FindGameObjectWithTag("CharacterController").GetComponent<CharacterSelection>();
		players = new GameObject[4];

		AssignPlayers();

		for(int i = 0; i < players.Length; i++)
		{
			if(i>= characterSel.control.Length)
				players[i].SetActive(false);

		}
       

		rewiredInputController = GameObject.FindGameObjectWithTag ("Rewired");
		
		if (rewiredInputController == null) {
			Instantiate(rewiredInputControllerPrefab , Vector3.zero , Quaternion.identity);
		}
    }

    void Start()
    {
        Score = new float[4];
        for (int i = 0; i < Score.Length; i++)
        {
            Score[i] = 0;
        }
    

    Random.Range(0, battleThemesName.Length);
        Invoke("Mooseca", 0.05f);

	}


	void Mooseca()
	{
		AudioManager.instance.PlaySound (countdown);
		musicSelector = Random.Range (0, battleThemesName.Length);
		AudioManager.instance.PlaySound (battleThemesName [musicSelector]);
		AudioManager.instance.setVolume (battleThemesName [musicSelector], 0.05f);
		Invoke ("BattleThemeVolume", 1);


	}

    void BattleThemeVolume()
	{

        AudioManager.instance.FadeMusic(battleThemesName[musicSelector], 0.7f, .09f);


    }

    void Update ()
    {
        GameTimer();
		Pause ();
	}

    public void AssignScore(string player , float value)
    {
        Debug.Log("Scorato");

        if (player == ("Player1"))
            Score[0] += value;
        if (player == ("Player2"))
            Score[1] += value;
        if (player == ("Player3"))
            Score[2] += value;
        if (player == ("Player4"))
            Score[3] += value;
    }
	private void AssignPlayers()
	{
		if(GameObject.Find("Player1").activeInHierarchy)
			players[0] = GameObject.Find("Player1");
		
		if (GameObject.Find("Player2").activeInHierarchy)
			players[1] = GameObject.Find("Player2");
		
		if (GameObject.Find("Player3").activeInHierarchy)
			players[2] = GameObject.Find("Player3");
		
		if (GameObject.Find("Player4").activeInHierarchy)
			players[3] = GameObject.Find("Player4");
	}

    private void ResetGame()
    {
        if (Input.GetKey(KeyCode.Space))
            Application.LoadLevel(Application.loadedLevel);
    }

	private void EndGame()
	{
		Debug.Log ("gioco finito");
		Application.LoadLevel ("ScoreScene");
	}

    private void GameTimer()
    {
		if (Application.loadedLevelName.Equals ("GameScene")) {
			timerSecond -= 1 * Time.deltaTime;


			timeMinuteLabel.text = timerMinute.ToString ("00") + ":" + timerSecond.ToString ("00");

			if (timerSecond <= 0 && timerMinute > 0) {
				timerMinute -= 1.0f;
				timerSecond = 59.0f;
			}
			if (timerMinute == 0.0f) {
                if (timerSecond <= 0.0f)
                {
                    EndGame();

                    PlayerPrefs.SetString("Player1Score", Score[0].ToString() + " P1");
                    PlayerPrefs.SetString("Player2Score", Score[1].ToString() + " P2");
                    PlayerPrefs.SetString("Player3Score", Score[2].ToString() + " P3");
                    PlayerPrefs.SetString("Player4Score", Score[3].ToString() + " P4");
                }
			}
		}
    }

    private void Pause()
    {
		for (int i = 0; i < players.Length; i++) {
			if (GetButtonDown (i, "StartButton")) {
				pauseMenu.SetActive (true);
				pauseMenu.GetComponent<UITweener> ().PlayForward ();
				Time.timeScale = 0;
			}
		}

    }

	public void Resume(){
		pauseMenu.GetComponent<UITweener> ().PlayReverse();
		Time.timeScale = 1f;
	}
	public void DeactiveMenu(){
		pauseMenu.SetActive (false);
	}
	public void LoadCharacterSelection(){
		Application.LoadLevel ("CharacterSelection");
	}
	public void GoToMenu(){
		Application.LoadLevel ("Title");
	}


    private void Play()
    {
        Time.timeScale = 1;
    }

	//rewired part
	bool GetButton(int player, string name)
	{
		return Rewired.ReInput.players.GetPlayer(player).GetButton(name);
	}

	bool GetButtonDown(int player, string name)
	{
		return Rewired.ReInput.players.GetPlayer(player).GetButtonDown(name);
	}

	float GetAxis(int player, string name)
	{
		return Rewired.ReInput.players.GetPlayer(player).GetAxis(name);
	}


}
