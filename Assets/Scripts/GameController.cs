using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;

    [HideInInspector]
    public float[] Score;

	public float timerSecond;
	public float timerMinute;

	public UILabel timeSecondLabel;
	public UILabel timeMinuteLabel;

	public GameObject rewiredInputControllerPrefab;
	private GameObject rewiredInputController;


    void Awake()
    {
		Time.timeScale = 1.0f; 
        instance = this;

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
<<<<<<< HEAD

        musicSelector= Random.Range(0, battleThemesName.Length);
        Invoke("Mooseca", 0.05f);

    }


    void Mooseca()
    {
        AudioManager.instance.PlaySound(countdown);
        AudioManager.instance.PlaySound(battleThemesName[musicSelector]);
        AudioManager.instance.setVolume(battleThemesName[musicSelector], 0.2f);
        Invoke("BattleThemeVolume", 4);

    }

    void BattleThemeVolume()
    {

        AudioManager.instance.setVolume(battleThemesName[musicSelector], 0.7f);


=======
>>>>>>> 8db6441c338ee4ea6d8c759c531f98d99e4b2d11
    }

    void Update ()
    {
		timerSecond -= 1 * Time.deltaTime;
		

		timeMinuteLabel.text = timerMinute.ToString ("00") + ":" + timerSecond.ToString ("00");
		
		if (timerSecond <= 0 && timerMinute > 0)  
		{ 
			timerMinute -= 1.0f;
			timerSecond = 59.0f;
		}
		if (timerMinute == 0.0f) {
			if (timerSecond <= 0.0f) 
				EndGame ();
		}
	}

    public void AssignScore(GameObject player , float value)
    {
        if (player.name == ("Player1"))
            Score[0] += value;
        if (player.name == ("Player2"))
            Score[1] += value;
        if (player.name == ("Player3"))
            Score[2] += value;
        if (player.name == ("Player4"))
            Score[3] += value;
    }

    private void ResetGame()
    {
        if (Input.GetKey(KeyCode.Space))
            Application.LoadLevel(Application.loadedLevel);
    }

	private void EndGame()
	{
		Debug.Log ("gioco finito");
		Time.timeScale = 0.0f;
	}
}
