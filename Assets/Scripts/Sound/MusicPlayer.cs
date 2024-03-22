using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    // Variables
    [Header("Title Text")]
    public TMP_Text titleText;
    [Header("Slider")]
    public Slider slider;
    [Header("Progress Text")]
    public TMP_Text progressText;
    //[Header("Time Counter")]
    int elapsedSeconds;
    int minutes;
    int totalSeconds;
    int totalMinutes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void SetMusicPlayer(string clipName, float clipLength)
    {
        SetMusicNameText(clipName);
        SetSliderValue(clipLength);
    }

    public void SetMusicNameText(string clipName)
    {
        titleText.text = clipName;
        Debug.Log($"Name of current song is: {clipName}");
    }

    public void SetSliderValue(float clipLength)
    {
        slider.maxValue = clipLength;
        slider.value = 0.0f;
        Debug.Log($"Value of current song is: {clipLength}");
    }

    public void MusicProgressBar(float audioSourcePlaytime, float clipLength)
    {
        // Calculate the elapsed time in seconds
        elapsedSeconds = Mathf.RoundToInt(audioSourcePlaytime % 60);

        // Calculate the elapsed time in minutes
        minutes = Mathf.FloorToInt(audioSourcePlaytime / 60);

        // Calculate the total song duration in seconds
        totalSeconds = Mathf.RoundToInt(clipLength % 60);

        // Calculate minutes from total seconds
        totalMinutes = Mathf.FloorToInt(clipLength) / 60;

        // Update the UI text with the progress (e.g., "3:48")
        progressText.text = $"{minutes}:{elapsedSeconds:D2}/{totalMinutes}:{totalSeconds:D2}";

        // Setting the slider values
        slider.value = audioSourcePlaytime;
    }
}
