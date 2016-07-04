using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject pressAnyKey;
	public GameObject gameTitle;
    public GameObject play;
	public GameObject setTime;
	public GameObject menu;
	public GameObject settings;
	public GameObject settingsTitle;
	public GameObject settingsMenu;
    public GameObject credits;
	public GameObject creditsImage;
    public GameObject exit;
	public GameObject exitMenu;

	public bool secondTemp;
	public float second = 0f;
	public float minute = 0f;
	public UILabel timer;

	void Start () 
	{
		secondTemp = true;
	}

	void Update () 
	{
		MenuFunction();
		Undo();   
		SetGameTime();
    }

	public void MenuFunction()
	{
		if (Input.anyKeyDown) {
			pressAnyKey.SetActive(false);
			gameTitle.GetComponent<TweenPosition>().PlayForward();
			play.GetComponent<TweenPosition>().PlayForward();
			play.GetComponent<TweenAlpha>().PlayForward();
			settings.GetComponent<TweenPosition>().PlayForward();
			settings.GetComponent<TweenAlpha>().PlayForward();
			credits.GetComponent<TweenPosition>().PlayForward();
			credits.GetComponent<TweenAlpha>().PlayForward();
			exit.GetComponent<TweenPosition>().PlayForward();
			exit.GetComponent<TweenAlpha>().PlayForward();

		}
	}

	//mainMenu
    public void Play()
	{
		menu.GetComponent<TweenPosition>().PlayForward();
		setTime.GetComponent<TweenPosition>().PlayForward();
    }

	public void Settings() 
	{
		menu.GetComponent<TweenPosition>().PlayForward();
		settingsMenu.GetComponent<TweenPosition>().PlayForward();
	}

	public void SettingsBack()
	{
		menu.GetComponent<TweenPosition>().PlayReverse();
		settingsMenu.GetComponent<TweenPosition>().PlayReverse();
	}

    public void Credits()
    {
		menu.GetComponent<TweenPosition>().PlayForward();
		creditsImage.GetComponent<TweenPosition>().PlayForward();
    }

    public void Exit()
    {
		menu.GetComponent<TweenPosition>().PlayForward();
		exitMenu.GetComponent<TweenPosition>().PlayForward();
    }

	//ExitMenu
	public void ExitYes()
	{
		Application.Quit ();
	}
	public void ExitNo()
	{
		menu.GetComponent<TweenPosition>().PlayReverse();
		exitMenu.GetComponent<TweenPosition>().PlayReverse();
	}

	//CreditsUndo
	public void Undo()
	{
		for(int i=0;i<4;i++){
			if(GetButtonDown(i,"DeselectB"))
			{
				menu.GetComponent<TweenPosition>().PlayReverse();
				creditsImage.GetComponent<TweenPosition>().PlayReverse();
			
			}
		}
	}

	//SetTimer
	public void SetGameTime()
	{
		timer.text = minute.ToString() +" : " + second.ToString();
		Debug.Log (secondTemp);
		if (GetButtonDown (0, "ArrowUp")){
			if ( secondTemp == true){
				second = 30;
				secondTemp = false;
			}
			else if ( secondTemp == false){
				second = 0;
				minute++;
				secondTemp = true;
			}
		}
		if (GetButtonDown (0, "ArrowDown") && minute > 0) {
			if ( secondTemp == true){
				second = 30;
				minute--;
				secondTemp = false;
			}
			else if ( secondTemp == false){
				second = 0;
				secondTemp = true;
			}
		}

	}

	//rewired
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
