using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    // Variables
    [Header("Player Info")]
    public GameObject player;
    public bool isPlayerDead;
    public bool playerWon;
    /*public int playerScore;
    [Header("UI Things")]
    public TMP_Text pointsPlayer;
    public TMP_Text timer;
    public float time;*/
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GameObject.Find("Player");

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
        isPlayerDead = player.GetComponent<PlayerStats>().isPlayerDead;
        playerWon = player.GetComponent<PlayerStats>().playerWon;
    }
}
