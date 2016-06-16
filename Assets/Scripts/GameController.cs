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

    public void AssignScore(string player , float value)
    {
        if (player == ("Player1"))
            Score[0] += value;
        if (player == ("Player2"))
            Score[1] += value;
        if (player == ("Player3"))
            Score[2] += value;
        if (player == ("Player4"))
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
