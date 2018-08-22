using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //  AudioSource audioSource = gameObject.AddComponent<AudioSource>();



    public AudioSource audioBackgorundMusic;
    public AudioClip[] backggroundMusic;
    private int musicIndex;


    [Range(0.0f, 1.0f)]
    public float volume;
    [Range(0.0f, 3.0f)]
    public float pitch;
    // Use this for initialization
    void Start ()
    {


    }

    private void Awake()
    {
        audioBackgorundMusic = gameObject.AddComponent<AudioSource>();



        musicIndex = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            audioBackgorundMusic.clip = backggroundMusic[musicIndex];
            audioBackgorundMusic.volume = volume;
            audioBackgorundMusic.pitch = pitch;
            audioBackgorundMusic.Play();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("u"))
        {
            Debug.Log("loop song requested");
            LoadAudioClip("loop");
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("next song requested");
            LoadNextSong();
        }
        if (!audioBackgorundMusic.isPlaying)
        {
            Debug.Log("the song is over");
            LoadNextSong();
        }
        CheckSoundSettings();
    }
    public void LoadNextSong()
    {
        int maxIndex = backggroundMusic.Length;
        musicIndex++;
        if (musicIndex >= maxIndex)
        {
            musicIndex = 0;
        }
        audioBackgorundMusic.Stop();
        audioBackgorundMusic.clip = backggroundMusic[musicIndex];
        audioBackgorundMusic.Play();
        //SceneManager.GetActiveScene().buildIndex;
    }
    public void CheckSoundSettings()
    {

        audioBackgorundMusic.volume = volume;
        audioBackgorundMusic.pitch = pitch;

    }

    public void ChangeBackGroundMusic(AudioClip aMusic)
    {
        audioBackgorundMusic.Stop();
        audioBackgorundMusic.clip = aMusic;
    }

    public void LoadAudioClip(string aName)
    {
        int maxIndex = backggroundMusic.Length;
        for (int i = 0; i < maxIndex; i++)
        {
            if(aName.Equals(backggroundMusic[i].name))
            {
                audioBackgorundMusic.Stop();
                audioBackgorundMusic.clip = backggroundMusic[i];
                Debug.Log(aName + "Was Loaded as the background music");
                return;
            }
        }
    }
}
