using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject gameTitle;
    public GameObject play;
	public GameObject settings;
    public GameObject credits;
    public GameObject exit;
    public GameObject pressAnyKey;
	public GameObject menu;
	public GameObject settingsMenu;
	public GameObject creditsImage;
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
		
//        Application.Quit();
    }

	public void Undo()
	{
		Debug.Log (backToMenu);
		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 2 )
		{
			menu.GetComponent<TweenPosition>().PlayReverse();
			creditsImage.GetComponent<TweenPosition>().PlayReverse();
			gameTitle.GetComponent<TweenPosition>().PlayForward();
		}

		if(Input.GetKeyDown(KeyCode.Q) && backToMenu == 1 )
		{
			menu.GetComponent<TweenPosition>().PlayReverse();
			settingsMenu.GetComponent<TweenPosition>().PlayReverse();
			gameTitle.GetComponent<TweenPosition>().PlayForward();
		}
		
	}
}
