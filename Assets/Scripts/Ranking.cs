using UnityEngine;
using System.Collections;
using System;
using Rewired;

public class Ranking : MonoBehaviour {

	public UILabel[] ScoreText=new UILabel[4];
	public float[] Score = new float[4];
	public float[] ScoreTemp=new float[4];
	public GameObject[] PlayerNumPos = new GameObject[4];
	public UILabel[] PlayerNum = new UILabel[4];
	public UILabel[] Kills = new UILabel[4];

	public GameObject[] playersInGame;
	public Rewired.Controller[] control;
	public UISprite endGame;
	private bool endGameIsOn;
	void Awake () {

//		control = Rewired.ReInput.controllers.GetControllers(Rewired.ControllerType.Joystick);

//		for (int i=0; i<Score.Length; i++) {
////			Score[i]=GameController.instance.Score[i];
//			ScoreTemp[i]=GameController.instance.Score[i];
//		}

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

		for (int i = 0; i < PlayerNum.Length; i++) {
			for(int j = 0; j < ScoreTemp.Length; j++){
				if(ScoreTemp[i] == Score[j]){
					PlayerNum[i].transform.position = PlayerNumPos[j].transform.position;
				}
			}

		}
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
			for (int i=0; i<4; i++) {
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
