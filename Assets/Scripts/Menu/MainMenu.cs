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


	void Update () 
	{
		MenuFunction();
		Undo();   
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

    public void Play()
	{
//		Application.LoadLevel ("CharacterSelection");
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
	public void ExitYes()
	{
		Application.Quit ();
	}
	public void ExitNo()
	{
		menu.GetComponent<TweenPosition>().PlayReverse();
		exitMenu.GetComponent<TweenPosition>().PlayReverse();
	}

	public void Undo()
	{

		if(Input.GetKeyDown(KeyCode.Q))
		{
			menu.GetComponent<TweenPosition>().PlayReverse();
			creditsImage.GetComponent<TweenPosition>().PlayReverse();
			
		}
	
//
//		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 1 )
//		{
//			menu.GetComponent<TweenPosition>().PlayReverse();
//			settingsTitle.GetComponent<TweenAlpha>().PlayReverse();
//			settingsMenu.GetComponent<TweenPosition>().PlayReverse();
//
//		}
//
//		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 2 )
//		{
//			menu.GetComponent<TweenPosition>().PlayReverse();
//			creditsImage.GetComponent<TweenPosition>().PlayReverse();
//
//		}
//
//		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 3 )
//		{
//			ExitNo();
//			menu.GetComponent<TweenPosition>().PlayReverse();
//			exitMenu.GetComponent<TweenPosition>().PlayReverse();
//
//		}


		
	}
}
