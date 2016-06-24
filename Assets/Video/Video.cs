using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour {



    // Use this for initialization
    public Material mat;
    MovieTexture movie;
    Renderer r;


    void Awake() {
        r = GetComponent<Renderer>();
        ((MovieTexture)r.material.mainTexture).Play();
         movie = (MovieTexture)r.material.mainTexture;
        movie.loop = true;
    }

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.A))
        {
            r.material = mat;
            movie.Stop();
            ((MovieTexture)r.material.mainTexture).Play();
            movie = (MovieTexture)r.material.mainTexture;
            movie.loop = false;
            AudioManager.instance.PlaySound("M_Intro");
        }
	}

 
}
