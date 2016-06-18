using UnityEngine;
using System.Collections;


[System.Serializable]

public class Sound
{

    public string theName;
    public AudioClip clip;

    public int quantity = 1;

    AudioSource source;


    [Range(0f, 1f)]
    public float defaultVolume = 0.7f;

    public float duration;
    float volume;

    [Range(0.5f, 1.5f)]
    public float pitch = 1;


    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public bool loop;

   
    public Sound(Sound s)
    {
        theName = s.theName;
        clip = s.clip;
        defaultVolume= s.defaultVolume;
        duration = s.duration;
        pitch = s.pitch;
        randomPitch = s.randomPitch;
        randomVolume = s.randomVolume;
        loop = s.loop;
    }

    public void SetSource(AudioSource _source)
    {
        //inizializzazione suono
        source = _source;


        source.clip = clip;
        source.volume = defaultVolume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.loop = loop;
       // duration = clip.length;


    }

    public bool PlaySound()
    {


        //riproduzione
        if (source.isPlaying)
        {
            return false;

        }
        else
            source.Play();

        return true;
    }



    public void StopSound()
    {
        source.Stop();

    }

    public IEnumerator StopSoundDelay()
    {
        yield return new WaitForSeconds(duration);

        if (duration > 0)
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

    Sound[] usingSounds;
    int soundPointer = 0;


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


        int requiredSounds = 0;

        //creazione audio source con i suoni inseriti
        for (int i = 0; i < sounds.Length; i++)
        {

            requiredSounds += sounds[i].quantity;

          
        }

        usingSounds = new Sound[requiredSounds];


        for (int i = 0; i < sounds.Length; i++)
        {



            for (int j = 0; j < sounds[i].quantity; j++)
            {

                usingSounds[soundPointer] = new Sound(sounds[i]);
                usingSounds[soundPointer].theName = usingSounds[soundPointer].theName + "_" + j;
                GameObject _go = new GameObject("Sound_" + (soundPointer) + usingSounds[soundPointer].theName);
                usingSounds[soundPointer].SetSource(_go.AddComponent<AudioSource>());
                _go.transform.SetParent(this.transform);
                soundPointer++;

            }

        }

        for (int i = 0; i < musics.Length; i++)
        {


            GameObject _go = new GameObject("Music_" + i + musics[i].theName);
            musics[i].SetSource(_go.AddComponent<AudioSource>());
            _go.transform.SetParent(this.transform);

         
        }


    }



    public void PlaySound(string soundName)
    {

        //chiamata del suono tramite nome

        if (soundName.ToCharArray()[0] == 'S')
        {
            for (int i = 0; i < soundPointer; i++)
            {



                if (usingSounds[i].theName.Contains(soundName))
                {
                    if (usingSounds[i].PlaySound())
                    {
                  //      StartCoroutine(usingSounds[i].StopSoundDelay());
                        return;
                    }


                }


            }
        }


        //in alternativa cerca la musica

        else
        {

            for (int i = 0; i < musics.Length; i++)
            {

                //ricerca del suono

                if (musics[i].theName.Contains(soundName))
                {

                    //stop suono
                    if (musics[i].PlaySound())
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

            for (int i = 0; i < usingSounds.Length; i++)
            {
                //ricerca del suono


                if (usingSounds[i].theName == soundName)
                {
                    //ricerca del suono


                    usingSounds[i].StopSound();
                    return;
                }
            }
        }

        else

        {
            for (int i = 0; i < musics.Length; i++)
            {
                //ricerca del suono


                if (musics[i].theName == soundName)
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

            if (musics[i].theName == soundName)
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

        for (int i = 0; i < usingSounds.Length; i++)
        {

            if (!setOn)
                usingSounds[i].SetVolume(0);
            else
                usingSounds[i].CurrentVolume();

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

            if (musics[i].theName == soundName)
            {

                //modifica volume
                musics[i].Pause();
                return;
            }
        }

    }
}


