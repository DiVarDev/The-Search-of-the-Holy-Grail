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
    [Header("Game Manager Settings")]
    public GameObject game;
    public AudioSource gameAudioSource;
    [Header("Sound Manager Settings")]
    public GameObject music;
    public AudioSource musicAudioSource;
    [Header("Audio Mixer and Subgroup mixers")]
    public AudioMixer masterMixer;
    [Range(0f, 1f)]
    public float masterVolume;
    public AudioMixer musicMixer;
    [Range(0f, 1f)]
    public float musicVolume;
    public AudioMixer gameMixer;
    [Range(0f, 1f)]
    public float gameVolume;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GameObject.Find("Player");
        //pointsPlayer.text = player.GetComponent<PlayerMovement>().score.ToString();

        game = GameObject.Find("Sound Manager").transform.Find("Game").gameObject;
        gameAudioSource = game.GetComponent<AudioSource>();

        music = GameObject.Find("Sound Manager").transform.Find("Music").gameObject;
        musicAudioSource = music.GetComponent<AudioSource>();

        masterMixer = GameObject.Find("Sound Manager").transform.Find("Master").gameObject.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer;
        musicMixer = GameObject.Find("Sound Manager").transform.Find("Music").gameObject.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer;
        gameMixer = GameObject.Find("Sound Manager").transform.Find("Game").gameObject.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
