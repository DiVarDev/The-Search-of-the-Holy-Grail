using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variables
    [Header("Music Game Audio Source")]
    public AudioSource musicGame;
    public bool musicGameExist;
    [Header("Sound Game Audio Source")]
    public AudioSource soundGame;
    public bool soundGameExist;
    [Header("Music Menu Audio Source")]
    public AudioSource musicMenu;
    public bool musicMenuExist;
    [Header("Sound Menu Audio Source")]
    public AudioSource soundMenu;
    public bool soundMenuExist;

    // Start is called before the first frame update
    void Start()
    {
        CheckAudioSourcesExistence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    private void CheckAudioSourcesExistence()
    {
        // Menu Music
        musicMenuExist = GameObject.Find("Sound Manager").transform.Find("Music Menu");
        if (musicMenuExist)
        {
            musicMenu = GameObject.Find("Sound Manager").transform.Find("Music Menu").GetComponent<AudioSource>();
        }

        musicGameExist = GameObject.Find("Sound Manager").transform.Find("Music Game");
        if (musicGameExist)
        {
            musicGame = GameObject.Find("Sound Manager").transform.Find("Music Game").GetComponent<AudioSource>();
        }

        soundMenuExist = GameObject.Find("Sound Manager").transform.Find("Sound Menu");
        if (soundMenuExist)
        {
            soundMenu = GameObject.Find("Sound Manager").transform.Find("Sound Menu").GetComponent<AudioSource>();
        }

        soundGameExist = GameObject.Find("Sound Manager").transform.Find("Sound Game");
        if (soundGameExist)
        {
            soundGame = GameObject.Find("Sound Manager").transform.Find("Sound Game").GetComponent<AudioSource>();
        }
    }
}
