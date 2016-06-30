using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour {



    // Use this for initialization
  
	private int firstTime;
	public string shots= "M_Shots", intro ="M_Intro", mainTheme= "M_MainTheme";
	Animator anim;
	public int startTime=1;


    void Awake() {
		firstTime = 0;
		anim = GetComponent<Animator> ();
    }


	void Start(){
	
		AudioManager.instance.PlaySound (intro);
		AudioManager.instance.setVolume (intro, 0.1f);
			AudioManager.instance.FadeMusic(intro,0.7f,0.5f);

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


	void StartMainTheme(){

		AudioManager.instance.PlaySound (mainTheme);
	}
 
}
