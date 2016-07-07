using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour {



    // Use this for initialization
  
	private int firstTime;
	public string shots= "M_Shots", intro ="M_Intro", mainTheme= "M_MainTheme";
	Animator anim;
	public int startTime=1;
    float fadeSpeed = 0.01f, fadeLimit = 0.7f;


    void Awake() {

    }



	void Start(){
        firstTime = 0;
        anim = GetComponent<Animator>();
        StartCoroutine("StartSounds");	}


    IEnumerator StartSounds() {
        yield return new WaitForEndOfFrame();
        AudioManager.instance.stopAllMusic();
        AudioManager.instance.StopAllSounds();

        AudioManager.instance.PlaySound (intro);
        AudioManager.instance.setVolume (intro, 0.01f);
        AudioManager.instance.FadeMusic(intro,fadeLimit,fadeSpeed);
        Invoke("QuickFade", 1);
    }
    // Update is called once per frame
    void Update () {


		if (Input.anyKeyDown && firstTime <= 0)
        {
			anim.SetBool("isStarted",true);
            AudioManager.instance.PlaySound(shots);
			AudioManager.instance.FadeMusic(intro,0,0.5f);
			firstTime++;
			Invoke("StartMainTheme", startTime);
        }
	}


    void QuickFade()
    {
        AudioManager.instance.FadeMusic(intro, fadeLimit, fadeSpeed*10);

    }

    void StartMainTheme(){
		AudioManager.instance.StopSound (intro);
		AudioManager.instance.PlaySound (mainTheme);
	}
 
}
