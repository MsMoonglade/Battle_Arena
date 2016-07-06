using UnityEngine;
using System.Collections;
using System;
using Rewired;

public class Ranking : MonoBehaviour {

	public UILabel[] ScoreText=new UILabel[4];
	public string[] Score = new string[4];
	public UISprite[] UiBars;
	public GameObject[] PlayerNumPos = new GameObject[4];
	public UILabel[] PlayerNum = new UILabel[4];
	public UILabel[] Kills = new UILabel[4];


	public GameObject[] playersInGame;
	public Rewired.Controller[] control;
	public UISprite endGame;
	private bool endGameIsOn;

    void Awake() {

        //		control = Rewired.ReInput.controllers.GetControllers(Rewired.ControllerType.Joystick);

        //		for (int i=0; i<Score.Length; i++) {
        ////			Score[i]=GameController.instance.Score[i];
        //			ScoreTemp[i]=GameController.instance.Score[i];
        //		}

        Score[0] = PlayerPrefs.GetString("Player1Score");
        Score[1] = PlayerPrefs.GetString("Player2Score");
        Score[2] = PlayerPrefs.GetString("Player3Score");
        Score[3] = PlayerPrefs.GetString("Player4Score");

        Array.Sort (Score);
		Array.Reverse (Score);

        //
        //		for (int i=0; i<control.Length; i++) {
        //			playersInGame[i].SetActive(true);
        //		}
        //
        //		for (int i=0; i<Score.Length; i++) {
        //			ScoreText[i].text=Score[i].ToString();
        //		}

        /*	for (int i = 0; i < PlayerNum.Length; i++) {
                for(int j = 0; j < ScoreTemp.Length; j++){
                    if(ScoreTemp[i] == Score[j]){
                        PlayerNum[i].transform.position = PlayerNumPos[j].transform.position;
                    }
                }

            }*/

        DisablePlayer();
        SetPosition();

    }

	void Update(){
		if(GetButtonDown(0,"StartButton")){
			endGame.GetComponent<UITweener>().PlayForward();
			endGameIsOn=true;
		}
		if(GetButtonDown(0,"DeselectB")){
			endGame.GetComponent<UITweener>().PlayReverse();
			endGameIsOn=false;
		}
	}

    private void SetPosition()
    {
        string[] player1String = Score[0].Split(" "[0]);
        string[] player2String = Score[1].Split(" "[0]);
        string[] player3String = Score[2].Split(" "[0]);
        string[] player4String = Score[3].Split(" "[0]);

        PlayerNum[0].text = player1String[1];
        PlayerNum[1].text = player2String[1];
        PlayerNum[2].text = player3String[1];
        PlayerNum[3].text = player4String[1];

        ScoreText[0].text = player1String[0];
        ScoreText[1].text = player2String[0];
        ScoreText[2].text = player3String[0];
        ScoreText[3].text = player4String[0];
    }

    private void DisablePlayer()
    {
        int numberOfPlayer = PlayerPrefs.GetInt("NumberOfPlayer");

        for (int i = 0; i < Score.Length; i++)
        {
            if (i >= numberOfPlayer)
            {
                UiBars[i].enabled = false;
                ScoreText[i].enabled = false;
                PlayerNum[i].enabled = false;
            }
        }
    }

	public void Quit(){
		if(endGameIsOn)
		Application.LoadLevel ("Title");
	}
	public void SelectCharacter(){
		if(endGameIsOn)
		Application.LoadLevel ("CharacterSelection");
	}
	public void Restart(){

		if (endGameIsOn) {
			for (int i=0; i< GameController.instance.Score.Length ; i++) {
				GameController.instance.Score [i] = 0;
			}
			Application.LoadLevel ("GameScene");
		}
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
