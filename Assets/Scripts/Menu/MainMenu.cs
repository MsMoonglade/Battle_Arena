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
	private bool ready= false;

	public GameObject lastSelection;

	[HideInInspector]
	public bool secondTemp;
	[HideInInspector]
	public float second = 0f;
	[HideInInspector]
	public float minute = 3f;
	
	private float timerSel;
	private bool timerIsOn;
	private float delay=0.1f;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}

	void Start () 
	{
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
		if (timerIsOn) {
			timerSel+=Time.deltaTime;

		}


		MenuFunction();
		Undo();   
		SetGameTime();

		if (GetButtonDown (0, "SelectA") && ready) {
			Application.LoadLevel("CharacterSelection");
			
		}
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
			play.SetActive(true);
		}
	}

	//mainMenu
    public void Play()
	{
		setTime.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		setTime.GetComponent<TweenPosition>().PlayForward();
    }

	public void Settings() 
	{
//		menu.SetActive (false);
//		settingsMenu.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		settingsMenu.GetComponent<TweenPosition>().PlayForward();
	}

	public void SettingsBack()
	{
		lastSelection = UIButton.current.gameObject;
		menu.GetComponent<TweenPosition>().PlayReverse();
		settingsMenu.GetComponent<TweenPosition>().PlayReverse();
		UICamera.selectedObject = lastSelection;
	}

    public void Credits()
    {
//		creditsImage.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		creditsImage.GetComponent<TweenPosition>().PlayForward();
    }

    public void Exit()
    {
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
		lastSelection = UIButton.current.gameObject;
		menu.GetComponent<TweenPosition>().PlayReverse();
		exitMenu.GetComponent<TweenPosition>().PlayReverse();
		UICamera.selectedObject = lastSelection;
	}

	//CreditsUndo
	public void Undo()
	{

		for(int i=0;i<4;i++){
			if(GetButtonDown(i,"DeselectB"))
			{
				settingsMenu.GetComponent<TweenPosition>().PlayReverse();
				menu.GetComponent<TweenPosition>().PlayReverse();
				creditsImage.GetComponent<TweenPosition>().PlayReverse();
				setTime.GetComponent<TweenPosition>().PlayReverse();
				exitMenu.GetComponent<TweenPosition>().PlayReverse();
	
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
