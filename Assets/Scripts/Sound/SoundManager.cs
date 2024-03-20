using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // Variables
    public bool isObjectDestroyOnLoad = false;
    [Header("Current Scene Information")]
    public int sceneIndex;
    public string sceneName;
    [Header("Music Information")]
    public List<AudioClip> musicMenuList;
    public List<AudioClip> musicLoseMenuList;
    public List<AudioClip> musicWinMenuList;
    public List<AudioClip> musicLightForestList;
    public List<AudioClip> musicDarkForestList;
    public List<AudioClip> musicDungeonList;
    public List<AudioClip> musicListSelected;
    public int musicListCount;
    public int currentTrackSelected;
    public string currentSong;
    public float songLenght;
    [Header("Music Audio Source")]
    public AudioSource audioSource;
    [Range(0.0f, 1.0f)]
    public float volume;
    public float audioSourcePlaytime;
    [Header("Music Player Components")]
    public GameObject musicPlayerPanel;
    public MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (!isObjectDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneIndex)
        {
            case 0:
                musicListSelected = musicMenuList;
                audioSource = gameObject.transform.Find("Music Menu").GetComponent<AudioSource>();
                break;

            case 1:
                musicListSelected = musicLightForestList;
                audioSource = gameObject.transform.Find("Music Game").GetComponent<AudioSource>();
                break;

            case 2:
                musicListSelected = musicDarkForestList;
                audioSource = gameObject.transform.Find("Music Game").GetComponent<AudioSource>();
                break;

            case 3:
                musicListSelected = musicDungeonList;
                audioSource = gameObject.transform.Find("Music Game").GetComponent<AudioSource>();
                break;

            case 4:
                musicListSelected = musicLoseMenuList;
                audioSource = gameObject.transform.Find("Music Menu").GetComponent<AudioSource>();
                break;

            case 5:
                musicListSelected = musicWinMenuList;
                audioSource = gameObject.transform.Find("Music Menu").GetComponent<AudioSource>();
                break;
        }

        currentTrackSelected = musicListSelected.IndexOf(musicListSelected.First());
        musicListCount = musicListSelected.Count - 1;

        volume = 0.5f;

        audioSource.clip = musicListSelected.ElementAt(currentTrackSelected);
        currentSong = audioSource.clip.name;
        songLenght = audioSource.clip.length;

        //try
        {
            musicPlayerPanel = GameObject.Find("Canvas").transform.Find("Music Player Panel").gameObject;
            musicPlayer = musicPlayerPanel.GetComponent<MusicPlayer>();
            musicPlayer.SetMusicPlayer(audioSource.clip.name, audioSource.clip.length);
        }
        /*catch (NullReferenceException ex)
        {
            Debug.LogError($"Error finding Music Player Panel: {ex.Message}.");
        }*/

        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;
        audioSourcePlaytime = audioSource.time;
        if (musicPlayerPanel != null)
        {
            musicPlayer.MusicProgressBar(audioSourcePlaytime, audioSource.clip.length);
        }
        if (audioSourcePlaytime >= songLenght)
        {
            StopMusic();
            NextTrack();
            PlayMusic();
        }
    }

    // Functions
    public void NextTrack()
    {
        if (currentTrackSelected < musicListSelected.Count - 1)
        {
            currentTrackSelected++;
        }
        else if (currentTrackSelected >= musicListSelected.Count - 1)
        {
            currentTrackSelected = musicListSelected.IndexOf(musicListSelected.First());
        }
        audioSource.clip = musicListSelected.ElementAt(currentTrackSelected);
        currentSong = audioSource.clip.name;
        songLenght = audioSource.clip.length;
        if (musicPlayerPanel != null)
        {
            musicPlayer.SetMusicPlayer(audioSource.clip.name, audioSource.clip.length);
        }
    }

    public void PlayMusic()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void PauseMusic()
    {
        if (audioSource.clip != null)
        {
            audioSource.Pause();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void StopMusic()
    {
        if (audioSource.clip != null)
        {
            audioSource.Stop();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }
}
