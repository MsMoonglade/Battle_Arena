using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;

    [HideInInspector]
    public float[] Score;

	public float timer;
	public UILabel timeLabel;

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
		/*timer -= 1 * Time.deltaTime;
		timeLabel.text = timer.ToString ("F2");

        ResetGame();

		if (timer < 0)
			EndGame ();*/
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
