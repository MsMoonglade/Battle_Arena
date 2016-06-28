using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour {



    // Use this for initialization
    public Material mat;
    MovieTexture movie;
    Renderer r;
	private int firstTime;
    public string shotsSound = "M_Intro", intro = "M_IntroDub", mainTheme = "M_MainTheme";

    void Awake() {
		firstTime = 0;
        r = GetComponent<Renderer>();
        ((MovieTexture)r.material.mainTexture).Play();
         movie = (MovieTexture)r.material.mainTexture;
        movie.loop = true;
    }

    void Start()
    {
        AudioManager.instance.PlaySound(intro);

    }

    // Update is called once per frame
    void Update () {


		if (Input.anyKeyDown && firstTime <= 0)
        {
            r.material = mat;
            movie.Stop();
            ((MovieTexture)r.material.mainTexture).Play();
            movie = (MovieTexture)r.material.mainTexture;
            movie.loop = false;
            AudioManager.instance.PlaySound(shotsSound);
            firstTime++;
            AudioManager.instance.FadeMusic(intro, 0, .5f);
            Invoke("PlayMain", 3);
        }
	}

    void PlayMain()
    {
        AudioManager.instance.StopSound(intro);

        AudioManager.instance.PlaySound(mainTheme);

    }

}
