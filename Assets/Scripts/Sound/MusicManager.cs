using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Variables
    [Header("Original Music List")]
    public List<AudioClip> musicList;
    public int currentTrackSelected;
    public int musicListCount;

    [Header("Music Audio Source")]
    public AudioSource audioSource;
    [Range(0.0f, 1.0f)]
    public float volume;
    public AudioClip currentSong;
    public float songLenght;
    public float audioSourcePlaytime;


    // Start is called before the first frame update
    void Start()
    {
        currentTrackSelected = musicList.IndexOf(musicList.First());
        musicListCount = musicList.Count - 1;

        audioSource = GetComponent<AudioSource>();

        volume = 0.5f;

        audioSource.clip = musicList.ElementAt(currentTrackSelected);
        currentSong = audioSource.clip;
        songLenght = audioSource.clip.length;
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;
        audioSourcePlaytime = audioSource.time;

        if (audioSourcePlaytime >= songLenght)
        {
            StopMusic();
            NextTrack();
            PlayMusic();
        }
    }

    // Function
    public void NextTrack()
    {
        if(currentTrackSelected < musicList.Count - 1)
        { 
            currentTrackSelected++;
        }
        else if(currentTrackSelected >= musicList.Count - 1)
        {
            currentTrackSelected = musicList.IndexOf(musicList.First());
        }
        audioSource.clip = musicList.ElementAt(currentTrackSelected);
        currentSong = audioSource.clip;
        songLenght = audioSource.clip.length;
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
