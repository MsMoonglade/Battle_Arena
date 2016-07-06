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
	public UILabel timer;

	private int menuNumber;
	
	[HideInInspector]
	public bool secondTemp;
	[HideInInspector]
	public float second = 0f;
	[HideInInspector]
	public float minute = 3f;
	
	private float timerSel;
	private bool timerIsOn;
	private float delay=0.1f;

	private TweenPosition Title;
	private TweenPosition PlayButton;
	private TweenPosition SettingsButton;
	private TweenPosition CreditsButton;
	private TweenPosition ExitButton;






	void Awake(){
		DontDestroyOnLoad (this.gameObject);

		Title = gameTitle.GetComponent<TweenPosition> ();
		PlayButton = play.GetComponent<TweenPosition> ();
		SettingsButton = settings.GetComponent<TweenPosition> ();
		CreditsButton = credits.GetComponent<TweenPosition> ();
		ExitButton = exit.GetComponent<TweenPosition> ();
	}

	void Start () 
	{
		menuNumber = 0;
		minute = 3f;
		secondTemp = true;
		play.SetActive (false);

		if (Application.loadedLevelName.Equals("GameScene")) 
		{
			GameController.instance.timerMinute = minute;
			GameController.instance.timerSecond = second;
		}

		setTime.SetActive (false);
//		settingsMenu.SetActive (false);
//		creditsImage.SetActive (false);
//		exitMenu.SetActive (false);


	}

	void Update () 
	{
		if (timerIsOn) 
			timerSel+=Time.deltaTime;
		
		MenuFunction();
		Undo();   
		SetGameTime();
					
    }

	
	public void MenuFunction()
	{
		if (Input.anyKeyDown) {
			pressAnyKey.SetActive(false);

			Title.PlayForward();
			PlayButton.PlayForward();
			SettingsButton.PlayForward();
			CreditsButton.PlayForward();
			ExitButton.PlayForward();
		
			play.SetActive(true);
		}
	}

//	public void PlayMenu()
//	{
//
//	}

	//mainMenu
    public void Play()
	{
		menuNumber = 1;
		setTime.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		setTime.GetComponent<TweenPosition>().PlayForward();
    }

	public void Settings() 
	{
		menuNumber = 2;
//		menu.SetActive (false);
//		settingsMenu.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		settingsMenu.GetComponent<TweenPosition>().PlayForward();
	}

	public void SettingsBack()
	{
		menuNumber = 0;
		menu.GetComponent<TweenPosition>().PlayReverse();
		settingsMenu.GetComponent<TweenPosition>().PlayReverse();

	}

    public void Credits()
    {
		menuNumber = 3;
//		creditsImage.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		creditsImage.GetComponent<TweenPosition>().PlayForward();
    }

    public void Exit()
    {
		menuNumber = 4;
//		exitMenu.SetActive (true);
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
		menuNumber = 0;
		menu.GetComponent<TweenPosition>().PlayReverse();
		exitMenu.GetComponent<TweenPosition>().PlayReverse();

	}

	//CreditsUndo
	public void Undo()
	{

		for(int i=0;i<4;i++){
			if(GetButtonDown(i,"DeselectB"))
			{

				switch(menuNumber)
				{
				case 0:
					menu.GetComponent<TweenPosition>().PlayReverse();
					settingsMenu.GetComponent<TweenPosition>().PlayReverse();
					break;
				case 1:
					setTime.GetComponent<TweenPosition>().PlayReverse();
					menu.GetComponent<TweenPosition>().PlayReverse();
					menuNumber=0;
					break;
				case 2:
					settingsMenu.GetComponent<TweenPosition>().PlayReverse();
					menu.GetComponent<TweenPosition>().PlayReverse();
					menuNumber=0;
					break;
				case 3:
					creditsImage.GetComponent<TweenPosition>().PlayReverse();
					menu.GetComponent<TweenPosition>().PlayReverse();
					menuNumber=0;
					break;
				case 4:
					exitMenu.GetComponent<TweenPosition>().PlayReverse();
					menu.GetComponent<TweenPosition>().PlayReverse();
					menuNumber=0;
					break;
				default:
					Debug.Log("ERRORE");
					menuNumber=0;
					break;
				}
	
			}
		}
	}

	//SetTimer
	public void SetGameTime()
	{
		timer.text = minute.ToString() +" : " + second.ToString();
		if (GetAxis (0, "LeftRotationH") >= 1 && minute < 5){
			timerIsOn=true;
			if(timerSel>delay){
			if ( secondTemp == true){
				second = 30;
				secondTemp = false;
			}
			else if ( secondTemp == false){
				second = 0;
				minute++;
				secondTemp = true;
			}
				timerIsOn=false;
				timerSel=0;
		}
		}
		if (GetAxis (0, "LeftRotationH") <= -1 && minute > 0) {
			timerIsOn = true;
			if (timerSel > delay) {
				if (secondTemp == true) {
					second = 30;
					minute--;
					secondTemp = false;
				} else if (secondTemp == false) {
					second = 0;
					secondTemp = true;
				}
				timerIsOn=false;
				timerSel=0;
			}
		}
	}
	public void StartGameY()
	{
		Application.LoadLevel("CharacterSelection");
	}
//	public void StartGameN()
//	{
//		Undo()
//	}


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
