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
	public GameObject readyToPlay;
    public GameObject aButton;
    public GameObject bButton;
    public UILabel timer;

	private int menuNumber;
	private bool ready;
	
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

	private string Confirm;
//	private TweenPosition ExitButton;

	

	void Awake(){
		DontDestroyOnLoad (this.gameObject);

		Title = gameTitle.GetComponent<TweenPosition> ();
		PlayButton = play.GetComponent<TweenPosition> ();
		SettingsButton = settings.GetComponent<TweenPosition> ();
		CreditsButton = credits.GetComponent<TweenPosition> ();
		ExitButton = exit.GetComponent<TweenPosition> ();
		Confirm = "S_Confirm";
	}

	void Start () 
	{
		ready = false;
		menuNumber = 0;
		minute = 3f;
		secondTemp = true;
		play.SetActive (false);


		setTime.SetActive (false);
//		settingsMenu.SetActive (false);
//		creditsImage.SetActive (false);
//		exitMenu.SetActive (false);


	}

	void Update () 
	{
	if (Application.loadedLevelName.Equals("CharacterSelection")) 
		{
			CharacterSelection.instance.timerMinute = minute;
		CharacterSelection.instance.timerSecond = second;
			Destroy(this.gameObject);
		}
	
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


	//mainMenu
    public void Play()
	{
		menuNumber = 1;
		setTime.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		setTime.GetComponent<TweenPosition>().PlayForward();
		AudioManager.instance.PlaySound (Confirm);
        ready = true;
    }

	public void Settings() 
	{
		menuNumber = 2;
//		menu.SetActive (false);
//		settingsMenu.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		settingsMenu.GetComponent<TweenPosition>().PlayForward();
        aButton.SetActive(false);
        bButton.SetActive(false);
		AudioManager.instance.PlaySound (Confirm);

    }

	public void SettingsBack()
	{
		menuNumber = 0;
		menu.GetComponent<TweenPosition>().PlayReverse();
		settingsMenu.GetComponent<TweenPosition>().PlayReverse();
		AudioManager.instance.PlaySound (Confirm);
        aButton.SetActive(true);
        bButton.SetActive(true);


    }

    public void Credits()
    {
		menuNumber = 3;
//		creditsImage.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		creditsImage.GetComponent<TweenPosition>().PlayForward();
		AudioManager.instance.PlaySound (Confirm);
    }

    public void Exit()
    {
		menuNumber = 4;
//		exitMenu.SetActive (true);
		menu.GetComponent<TweenPosition>().PlayForward();
		exitMenu.GetComponent<TweenPosition>().PlayForward();
		AudioManager.instance.PlaySound (Confirm);
        aButton.SetActive(false);
        bButton.SetActive(false);
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
        aButton.SetActive(true);
        bButton.SetActive(true);

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
                //PLay
				case 1:
					setTime.GetComponent<TweenPosition>().PlayReverse();
					menu.GetComponent<TweenPosition>().PlayReverse();
					menuNumber=0;
					break;
                //Settings
                case 2:
				//	settingsMenu.GetComponent<TweenPosition>().PlayReverse();
				//	menu.GetComponent<TweenPosition>().PlayReverse();
					menuNumber=0;
					break;
                //Credits
                case 3:
					creditsImage.GetComponent<TweenPosition>().PlayReverse();
					menu.GetComponent<TweenPosition>().PlayReverse();
					menuNumber=0;
					break;
                //Exit
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

	public void MusicOn (){
		AudioManager.instance.PlaySound (Confirm);
		AudioManager.instance.MusicsActivation (true);
	}

	public void MusicOff (){
		AudioManager.instance.PlaySound (Confirm);
		AudioManager.instance.MusicsActivation (false);
	}

	public void SoundOn (){
		AudioManager.instance.PlaySound (Confirm);
		AudioManager.instance.SoundsActivation (true);
	}

	public void SoundOff (){
		AudioManager.instance.SoundsActivation (false);
	}


	//SetTimer
	public void SetGameTime()
	{
		timer.text = minute.ToString() +" : " + second.ToString();
		if (GetAxis (0, "LeftRotationH") >= 0.7f && minute < 5){
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
		if (GetAxis (0, "LeftRotationH") <= -0.7f && minute > 0) {
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
        if (GetButtonDown(0, "SelectA") && ready)
        {
            //readyToPlay.SetActive(true);
            Application.LoadLevel("CharacterSelection");
            PlayerPrefs.SetFloat("second", second);
            PlayerPrefs.SetFloat("minute", minute);
            //setTime.SetActive(false);
            Debug.Log("ciao");
        }
        else if (GetButtonDown(0, "DeselectB")) {
            ready = false;
            Debug.Log("ciaone");
        }


    }
	public void StartGameY()
	{
		Application.LoadLevel("CharacterSelection");
	}

	public void StartGameN()
	{
		readyToPlay.SetActive (false);
		setTime.GetComponent<TweenPosition>().PlayReverse();
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
