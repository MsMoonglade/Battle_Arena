using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject gameTitle;
    public GameObject play;
    public GameObject settings;
    public GameObject credits;
    public GameObject exit;
    public GameObject pressAnyKey;

//	private bool activePlay;


	void Awake ()
	{
//		activePlay = false; 
	}
	void Start () 
	{
	

	}
	
	// Update is called once per frame
	void Update () 
	{
		MenuFunction ();

       
    }
	void MenuFunction()
	{
		if (Input.anyKeyDown) {
			pressAnyKey.SetActive(false);
			gameTitle.GetComponent<TweenAlpha> ().PlayForward ();
			play.GetComponent<TweenPosition>().PlayForward();
			play.GetComponent<TweenAlpha> ().PlayForward ();
			settings.GetComponent<TweenPosition>().PlayForward();
			settings.GetComponent<TweenAlpha> ().PlayForward ();
			credits.GetComponent<TweenPosition>().PlayForward();
			credits.GetComponent<TweenAlpha> ().PlayForward ();
			exit.GetComponent<TweenPosition>().PlayForward();
			exit.GetComponent<TweenAlpha> ().PlayForward ();

		}

	
	
	}

    public void Play()
	{
//		Application.LoadLevel ("CharacterSelection");
    }

    public void Settings()
    {
        
    }

    public void Credits()
    {
		Application.LoadLevel ("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
