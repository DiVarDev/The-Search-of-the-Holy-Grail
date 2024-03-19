using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    // Variables
    [Header("Music Text")]
    public TMP_Text musicPlaying;
    public Slider musicSlider;
    public TMP_Text musicProgress;
    int elapsedSeconds;
    int minutes;
    int totalSeconds;
    int totalMinutes;

    // Start is called before the first frame update
    void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        switch (scene)
        {
            case 0:
                musicPlaying = GameObject.Find("Canvas").transform.Find("Menu Panel")
                    .transform.Find("Music Player Panel").transform.Find("Music Playing Text")
                    .GetComponent<TMP_Text>();
                musicSlider = GameObject.Find("Canvas").transform.Find("Menu Panel")
                    .transform.Find("Music Player Panel").transform.Find("Music Progress Bar Slider")
                    .GetComponent<Slider>();
                musicProgress = GameObject.Find("Canvas").transform.Find("Menu Panel")
                    .transform.Find("Music Player Panel").transform.Find("Music Progress Text")
                    .GetComponent<TMP_Text>();
                break;

            case 1:
                musicPlaying = GameObject.Find("Game User Interface").transform.Find("Canvas")
                    .transform.Find("Music Player Panel").transform.Find("Music Playing Text")
                    .GetComponent<TMP_Text>();
                musicSlider = GameObject.Find("Game User Interface").transform.Find("Canvas")
                    .transform.Find("Music Player Panel").transform.Find("Music Progress Bar Slider")
                    .GetComponent<Slider>();
                musicProgress = GameObject.Find("Game User Interface").transform.Find("Canvas")
                    .transform.Find("Music Player Panel").transform.Find("Music Progress Text")
                    .GetComponent<TMP_Text>();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void SetMusicNameText(AudioClip currentSong)
    {
        musicPlaying.text = currentSong.name;
    }

    public void SetSliderValue(AudioClip currentSong)
    {
        musicSlider.maxValue = currentSong.length;
        musicSlider.value = 0.0f;
    }

    public void MusicProgressBar(float audioSourcePlaytime, AudioClip currentSong)
    {
        /*musicProgress.text = Mathf.RoundToInt(audioSourcePlaytime % 60) + "/" + Mathf.RoundToInt(currentSong.length % 60);*/

        // Calculate the elapsed time in seconds
        elapsedSeconds = Mathf.RoundToInt(audioSourcePlaytime % 60);

        // Calculate the elapsed time in minutes
        minutes = Mathf.FloorToInt(audioSourcePlaytime / 60);

        // Calculate the total song duration in seconds
        totalSeconds = Mathf.RoundToInt(currentSong.length % 60);

        // Calculate minutes from total seconds
        totalMinutes = Mathf.FloorToInt(currentSong.length) / 60;

        // Update the UI text with the progress (e.g., "3:48")
        musicProgress.text = $"{minutes}:{elapsedSeconds:D2}/{totalMinutes}:{totalSeconds:D2}";

        // Setting the slider values
        musicSlider.value = audioSourcePlaytime;
    }
}
