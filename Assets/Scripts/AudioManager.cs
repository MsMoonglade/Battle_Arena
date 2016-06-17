using UnityEngine;

[System.Serializable]

public class Sound
{

    public string name;
    public AudioClip clip;

    AudioSource source;

    [Range(0f, 1f)]
    public float defaultVolume = 0.7f;

    float volume;

    [Range(0.5f, 1.5f)]
    public float pitch = 1;

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public bool loop;


    public void SetSource(AudioSource _source)
    {

        //inizializzazione suono
        source = _source;
        Debug.Log(source.name);


        source.clip = clip;
        source.volume = defaultVolume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.loop = loop;


    }

    public void PlaySound()
    {

        //riproduzione
        source.Play();
    }

    public void StopSound()
    {

        source.Stop();
    }

    public void SetVolume(float _volume)
    {
        source.volume = _volume;
        volume = _volume;
    }


    public void CurrentVolume()
    {
        source.volume = volume;
    }

    public void Pause()
    {
        if (source.isPlaying)
        {
            source.Pause();
        }
        else source.UnPause();
    }

}

public class AudioManager : MonoBehaviour
{


    //Inserire i suoni nell'editor
    [SerializeField]
    Sound[] sounds;


    [SerializeField]
    Sound[] musics;

    public static AudioManager instance;
    void Awake()
    {


        if (instance != null)
        {

            if (instance != this)
                Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }


    }

    // Use this for initialization
    void Start()
    {


        //creazione audio source con i suoni inseriti
        for (int i = 0; i < sounds.Length; i++)
        {

            GameObject _go = new GameObject("Sound_" + i + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
            _go.transform.SetParent(this.transform);
        }

        for (int i = 0; i < musics.Length; i++)
        {

            GameObject _go = new GameObject("Music_" + i + musics[i].name);
            musics[i].SetSource(_go.AddComponent<AudioSource>());
            _go.transform.SetParent(this.transform);
        }


    }


    public void PlaySound(string soundName)
    {


        //chiamata del suono tramite nome

        if (soundName.ToCharArray()[0] == 'S')
        {
            for (int i = 0; i < sounds.Length; i++)
            {

                if (sounds[i].name == soundName)
                {
                    sounds[i].PlaySound();
                    return;
                }


            }
        }


        //in alternativa cerca la musica

        else
        {

            for (int i = 0; i < musics.Length; i++)
            {

                //ricerca del suono

                if (musics[i].name == soundName)
                {

                    //stop suono
                    Debug.Log(soundName + " . " + musics[i].name);
                    musics[i].PlaySound();
                    return;
                }
            }
        }



        Debug.LogError("Sound " + soundName + " doesn't exist");
    }

    public void StopSound(string soundName)
    {


        //chiamata del suono tramite nome

        if (soundName.ToCharArray()[0] == 'S')
        {

            for (int i = 0; i < sounds.Length; i++)
            {
                //ricerca del suono


                if (sounds[i].name == soundName)
                {
                    //ricerca del suono


                    sounds[i].StopSound();
                    return;
                }
            }
        }

        else

        {
            for (int i = 0; i < musics.Length; i++)
            {
                //ricerca del suono


                if (musics[i].name == soundName)
                {
                    //stop suono

                    musics[i].StopSound();
                    return;
                }
            }
        }



        Debug.LogError("Sound " + soundName + " doesn't exist");
    }


    public void setVolume(string soundName, float volume)
    {

        //chiamata del suono tramite nome


        for (int i = 0; i < musics.Length; i++)
        {

            //ricerca del suono

            if (musics[i].name == soundName)
            {

                //modifica volume
                musics[i].SetVolume(volume);
                return;
            }
        }

        Debug.LogError("Music " + soundName + " doesn't exist");
    }


    public void SoundsActivation(bool setOn)
    {

        for (int i = 0; i < sounds.Length; i++)
        {

            if (!setOn)
                sounds[i].SetVolume(0);
            else
                sounds[i].CurrentVolume();

        }

    }

    public void MusicsActivation(bool setOn)
    {

        for (int i = 0; i < musics.Length; i++)
        {

            if (!setOn)
                musics[i].SetVolume(0);
            else
                musics[i].CurrentVolume();

        }

    }

    public void PauseSound(string soundName)
    {


        for (int i = 0; i < musics.Length; i++)
        {

            //ricerca del suono

            if (musics[i].name == soundName)
            {

                //modifica volume
                musics[i].Pause();
                return;
            }
        }

    }
}


