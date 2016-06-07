using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;

    [HideInInspector]
    public float[] Score;

    void Awake()
    {
        instance = this;
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
        ResetGame();
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

}
