using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject pressAnyKey;
	public GameObject gameTitle;
    public GameObject play;
	public GameObject menu;
	public GameObject settings;
	public GameObject settingsTitle;
	public GameObject settingsMenu;
    public GameObject credits;
	public GameObject creditsImage;
    public GameObject exit;
	public GameObject exitMenu;



	private int backToMenu;




	void Awake ()
	{

	}

	void Start () 
	{
		backToMenu = 0;
		Debug.Log (backToMenu);
	}
	

	void Update () 
	{
		MenuFunction();
		Undo();

       
    }

	public void MenuFunction()
	{
	
		Debug.Log (backToMenu);
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

    public void Play()
	{
//		Application.LoadLevel ("CharacterSelection");
    }

	public void Settings() 
	{
		backToMenu = 1;
		Debug.Log (backToMenu);
		menu.GetComponent<TweenPosition>().PlayForward();
		gameTitle.GetComponent<TweenPosition>().PlayReverse();
		settingsTitle.GetComponent<TweenAlpha>().PlayForward();
		settingsMenu.GetComponent<TweenPosition>().PlayForward();

	}

    public void Credits()
    {
		backToMenu = 2;
		Debug.Log (backToMenu);
		menu.GetComponent<TweenPosition>().PlayForward();
		gameTitle.GetComponent<TweenPosition>().PlayReverse();
		creditsImage.GetComponent<TweenPosition>().PlayForward();


    }

    public void Exit()
    {
		backToMenu = 3;
		menu.GetComponent<TweenPosition>().PlayForward();
		gameTitle.GetComponent<TweenPosition>().PlayReverse();
		exitMenu.GetComponent<TweenPosition>().PlayForward();

    }

	public void Undo()
	{
	

		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 1 )
		{
			menu.GetComponent<TweenPosition>().PlayReverse();
			settingsTitle.GetComponent<TweenAlpha>().PlayReverse();
			settingsMenu.GetComponent<TweenPosition>().PlayReverse();
			gameTitle.GetComponent<TweenPosition>().PlayForward();
		}

		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 2 )
		{
			menu.GetComponent<TweenPosition>().PlayReverse();
			creditsImage.GetComponent<TweenPosition>().PlayReverse();
			gameTitle.GetComponent<TweenPosition>().PlayForward();
		}

		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 3 )
		{
			menu.GetComponent<TweenPosition>().PlayReverse();
			exitMenu.GetComponent<TweenPosition>().PlayReverse();
			gameTitle.GetComponent<TweenPosition>().PlayForward();
		}


		
	}
}
