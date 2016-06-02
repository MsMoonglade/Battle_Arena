using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject gameTitle;
    public GameObject play;
    public GameObject settings;
    public GameObject credits;
    public GameObject exit;
    public GameObject pressAnyKey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.A)) {
            pressAnyKey.SetActive(false);
            gameTitle.GetComponent<TweenPosition> ().PlayForward ();
            play.GetComponent<TweenPosition>().PlayForward();
            settings.GetComponent<TweenPosition>().PlayForward();
            credits.GetComponent<TweenPosition>().PlayForward();
            exit.GetComponent<TweenPosition>().PlayForward();
             
		}

       
    }

    public void Play()
    {
        Application.LoadLevel(1);
    }

    public void Settings()
    {
        gameTitle.SetActive(false);
        play.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
        exit.SetActive(false);
    }

    public void Credits()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
