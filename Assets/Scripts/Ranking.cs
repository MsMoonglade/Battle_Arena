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


	void Awake () {

		control = Rewired.ReInput.controllers.GetControllers(Rewired.ControllerType.Joystick);

		for (int i=0; i<Score.Length; i++) {
			Score[i]=GameController.instance.Score[i];
			ScoreTemp[i]=GameController.instance.Score[i];
		}

		Array.Sort (Score);
		Array.Reverse (Score);

		for (int i=0; i<control.Length; i++) {
			playersInGame[i].SetActive(true);
		}

		for (int i=0; i<Score.Length; i++) {
			ScoreText[i].text=Score[i].ToString();
		}

		for (int i = 0; i < PlayerNum.Length; i++) {
			for(int j = 0; j < ScoreTemp.Length; j++){
				if(ScoreTemp[i] == Score[j]){
					PlayerNum[i].transform.position = PlayerNumPos[j].transform.position;
				}
			}

		}
	}


}
