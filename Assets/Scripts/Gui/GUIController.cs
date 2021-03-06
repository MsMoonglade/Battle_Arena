﻿using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	

    public UILabel [] Score = new UILabel[4];

    private Player[] players;
	
	void Awake()
	{
		players = new Player[4];
		AssignPlayers ();

        for (int i = 0; i < Score.Length; i++)
        {
            Score[i].GetComponent<UILabel>();
        }

		for (int i = 0; i < Score.Length; i++) 
		{
			if(!players[i].gameObject.activeInHierarchy)
				Score[i].gameObject.SetActive(false);
		}
	}

	private void AssignPlayers()
	{
       
		    players [0] = GameObject.Find ("Player1").GetComponent<Player> ();
        
            players [1] = GameObject.Find ("Player2").GetComponent<Player> ();
       
            players [2] = GameObject.Find ("Player3").GetComponent<Player> ();
       
            players [3] = GameObject.Find ("Player4").GetComponent<Player> ();
	}

    void Update()
    {
        ScoreView();
    }

    void ScoreView()
    {
		Score[0].text = GameController.instance.Score[0].ToString("00") ;
		Score[1].text = GameController.instance.Score[1].ToString("00") ;
		Score[2].text = GameController.instance.Score[2].ToString("00") ;
		Score[3].text = GameController.instance.Score[3].ToString("00") ;
    }
}
