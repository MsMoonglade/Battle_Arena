using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour {



    // Use this for initialization
  
	private int firstTime;
	Animator anim;

    void Awake() {
		firstTime = 0;
		anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {


		if (Input.anyKeyDown && firstTime <= 0)
        {
			anim.SetBool("isStarted",true);
            AudioManager.instance.PlaySound("M_Intro");
			firstTime++;
        }
	}

 
}
