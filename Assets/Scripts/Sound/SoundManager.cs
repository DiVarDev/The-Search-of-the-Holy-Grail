using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // Variables
    public bool playMusic = true;
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
    public AudioSource musicMudioSource;
    [Range(0.0f, 1.0f)]
    public float volume;
    public float audioSourcePlaytime;
    [Header("Music Player Components")]
    public GameObject musicPlayerPanel;
    public MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneIndex)
        {
            case 0:
                musicListSelected = musicMenuList;
                musicMudioSource = transform.Find("Music Menu").GetComponent<AudioSource>();
                break;

            case 1:
                musicListSelected = musicLightForestList;
                musicMudioSource = transform.Find("Music Game").GetComponent<AudioSource>();
                break;

            case 2:
                musicListSelected = musicDarkForestList;
                musicMudioSource = transform.Find("Music Game").GetComponent<AudioSource>();
                break;

            case 3:
                musicListSelected = musicDungeonList;
                musicMudioSource = transform.Find("Music Game").GetComponent<AudioSource>();
                break;

            case 4:
                musicListSelected = musicLoseMenuList;
                musicMudioSource = transform.Find("Music Menu").GetComponent<AudioSource>();
                break;

            case 5:
                musicListSelected = musicWinMenuList;
                musicMudioSource = transform.Find("Music Menu").GetComponent<AudioSource>();
                break;
        }

        currentTrackSelected = musicListSelected.IndexOf(musicListSelected.First());
        musicListCount = musicListSelected.Count - 1;

        volume = 0.5f;

        musicMudioSource.clip = musicListSelected.ElementAt(currentTrackSelected);
        currentSong = musicMudioSource.clip.name;
        songLenght = musicMudioSource.clip.length;

        //try
        {
            musicPlayerPanel = GameObject.Find("Canvas").transform.Find("Music Player Panel").gameObject;
            musicPlayer = musicPlayerPanel.GetComponent<MusicPlayer>();
            musicPlayer.SetMusicPlayer(musicMudioSource.clip.name, musicMudioSource.clip.length);
        }
        /*catch (NullReferenceException ex)
        {
            Debug.LogError($"Error finding Music Player Panel: {ex.Message}.");
        }*/

        if (playMusic)
        {
            PlayMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        musicMudioSource.volume = volume;
        audioSourcePlaytime = musicMudioSource.time;
        if (musicPlayerPanel != null)
        {
            musicPlayer.MusicProgressBar(audioSourcePlaytime, musicMudioSource.clip.length);
        }
        if (audioSourcePlaytime >= songLenght)
        {
            StopMusic();
            NextTrack();
            if (playMusic)
            {
                PlayMusic();
            }
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
        musicMudioSource.clip = musicListSelected.ElementAt(currentTrackSelected);
        currentSong = musicMudioSource.clip.name;
        songLenght = musicMudioSource.clip.length;
        if (musicPlayerPanel != null)
        {
            musicPlayer.SetMusicPlayer(musicMudioSource.clip.name, musicMudioSource.clip.length);
        }
    }

    public void PlayMusic()
    {
        if (musicMudioSource.clip != null)
        {
            musicMudioSource.Play();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void PauseMusic()
    {
        if (musicMudioSource.clip != null)
        {
            musicMudioSource.Pause();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void StopMusic()
    {
        if (musicMudioSource.clip != null)
        {
            musicMudioSource.Stop();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }
}
