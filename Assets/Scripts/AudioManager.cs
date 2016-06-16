using UnityEngine;

[System.Serializable]

public class Sound {

	public string name;
	public AudioClip clip;

	AudioSource source;

	public float volume;
	public float pitch;


	public void SetSource(AudioSource _source){
	
		//inizializzazione suono

		source = _source;
		source.clip = clip;
		source.volume = volume =.7f;
		source.pitch = pitch=1;

	
	}

	public void PlaySound(){

		//riproduzione

		source.Play();
	}

}

public class AudioManager : MonoBehaviour {


	//Inserire i suoni nell'editor
	[SerializeField]
	Sound [] sounds;


	public static  AudioManager instance; 
	void Awake(){
	

		if(instance !=null)
			Debug.LogError("Multiple audio manager");
		else 
			instance=this;

	
	}

	// Use this for initialization
	void Start () {
	

		//creazione audio source con i suoni inseriti
		for (int i=0; i<sounds.Length; i++){

			GameObject _go = new GameObject("Sound_" + i  + sounds[i].name);
			sounds[i].SetSource(_go.AddComponent<AudioSource>());

		}


	}


	public void PlaySound(string soundName){


		//chiamata del suono tramite nome


		for (int i=0; i<sounds.Length; i++){

			if(sounds[i].name == soundName)
			{sounds[i].PlaySound();
				return;
			}
		}

		Debug.LogError ("Sound " + soundName + " doesn't exist");
	}

}


