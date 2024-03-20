using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    [Header("Player Info")]
    public GameObject player;
    public int health;
    public int keys;
    public bool isPlayerDead;
    public bool playerWon;
    public int playerScore;
    [Header("UI Things")]
    //public TMP_Text healthText;
    public Slider healthSlider;
    public TMP_Text keysText;
    public float time;
    [Header("Sound Manager")]
    public GameObject soundManager;
    public AudioSource soundManagerAudioSource;
    public AudioMixer masterMixer;
    [Range(0f, 1f)]
    public float masterVolume = 1.0f;
    [Header("Sound Game")]
    public GameObject soundGame;
    public AudioSource soundGameAudioSource;
    public AudioMixer gameMixer;
    [Range(0f, 1f)]
    public float soundGameVolume = 1.0f;
    [Header("Music Game")]
    public GameObject musicGame;
    public AudioSource musicGameAudioSource;
    public AudioMixer musicMixer;
    [Range(0f, 1f)]
    public float musicGameVolume = 1.0f;
        

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GameObject.Find("Player");
        keys = 0;

        //healthText = GameObject.Find("Canvas").transform.Find("Player Heath Text").GetComponent<TMP_Text>();
        healthSlider = GameObject.Find("Canvas").transform.Find("Health Slider").GetComponent<Slider>();
        healthSlider.maxValue = player.GetComponent<PlayerStats>().health;
        keysText = GameObject.Find("Canvas").transform.Find("Player Keys Text").GetComponent<TMP_Text>();

        soundManager = GameObject.Find("Sound Manager");
        soundManagerAudioSource = soundManager.GetComponent<AudioSource>();

        soundGame = soundManager.transform.Find("Sound Game").gameObject;
        soundGameAudioSource = soundGame.GetComponent<AudioSource>();

        musicGame = soundManager.transform.Find("Music Game").gameObject;
        musicGameAudioSource = musicGame.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerStats>().health;
        //healthText.text = health.ToString();
        healthSlider.value = player.GetComponent<PlayerStats>().health;
        keys = player.GetComponent<PlayerStats>().keys;
        keysText.text = keys.ToString();

        isPlayerDead = player.GetComponent<PlayerStats>().isDead;
        playerWon = player.GetComponent<PlayerStats>().playerWon;
    }
}
