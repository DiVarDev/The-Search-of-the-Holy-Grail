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
    public GameObject playerGameObject;
    public PlayerStats playerStatsScript;
    public PlayerMovement playerMovementScript;

    [Header("Sound Manager")]
    public GameObject soundManagerGameObject;
    public SoundManager soundManagerScript;
    public AudioSource soundManagerAudioSource;

    [Header("Scene Loader Script")]
    public SceneLoader sceneLoader;

    [Header("User Interface Components")]
    public GameObject canvasGameObject;
    public Slider healthSliderScript;
    public TMP_Text keysText;
    public TMP_Text timerText;
    public float time = 145.0f;

    [Header("Game Statistics Manager")]
    public GameObject gameStatsProgressGameObject;
    public GameStatsProgress gameStatsProgressScript;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerGameObject = GameObject.Find("Player");
        playerStatsScript = playerGameObject.GetComponent<PlayerStats>();
        playerStatsScript.health = playerStatsScript.maxHealth;
        playerMovementScript = playerGameObject.GetComponent<PlayerMovement>();
        
        soundManagerGameObject = GameObject.Find("Sound Manager").gameObject;
        soundManagerScript = soundManagerGameObject.GetComponent<SoundManager>();
        soundManagerAudioSource = soundManagerGameObject.GetComponent<AudioSource>();

        sceneLoader = gameObject.GetComponent<SceneLoader>();

        canvasGameObject = GameObject.Find("Canvas").gameObject;
        healthSliderScript = canvasGameObject.transform.Find("Health Slider").GetComponent<Slider>();
        healthSliderScript.maxValue = playerGameObject.GetComponent<PlayerStats>().maxHealth;
        keysText = canvasGameObject.transform.Find("Player Keys Text").GetComponent<TMP_Text>();
        timerText = canvasGameObject.transform.Find("Player Timer Text").GetComponent<TMP_Text>();

        gameStatsProgressGameObject = GameObject.Find("Game Stats Progress").gameObject;
        gameStatsProgressScript = gameStatsProgressGameObject.GetComponent<GameStatsProgress>();

        Debug.Log($"Scene detected: {soundManagerScript.sceneName} with index {soundManagerScript.sceneIndex}");

        if (gameStatsProgressScript.GetPlayerHealth() == 0 || gameStatsProgressScript.GetTimeLeft() == 0 || gameStatsProgressScript.GetKeysCollected() == 0)
        {
            Debug.Log("New Values Scriptable");
            gameStatsProgressScript.SetPlayerHealth(playerStatsScript.maxHealth);
            gameStatsProgressScript.SetTimeLeft(time);
            gameStatsProgressScript.SetKeysCollected(playerStatsScript.keys);
        }
        else
        {
            Debug.Log("Old Values Scriptable");
            playerStatsScript.health = gameStatsProgressScript.GetPlayerHealth();
            time = gameStatsProgressScript.GetTimeLeft();
            playerStatsScript.keys = gameStatsProgressScript.GetKeysCollected();
        }

        StartCoroutine(IniciarCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        healthSliderScript.value = playerGameObject.GetComponent<PlayerStats>().health;
        keysText.text = playerGameObject.GetComponent<PlayerStats>().keys.ToString();

        gameStatsProgressScript.SetPlayerHealth(playerStatsScript.health);
        gameStatsProgressScript.SetTimeLeft(time);
        gameStatsProgressScript.SetKeysCollected(playerStatsScript.keys);
    }

    // IEnumerators
    IEnumerator IniciarCountdown()
    {
        while (time > 0)
        {
            timerText.text = "Time Left: " + time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
        timerText.text = "Time ran out!";
        playerGameObject.GetComponent<PlayerStats>().isDead = true;
        Debug.Log("Player has run out of time...");
        playerGameObject.SetActive(false);
        HasLost();
    }

    // Functions
    public void HasWon()
    {
        Destroy(gameStatsProgressGameObject);
        Invoke("LoadWin", playerStatsScript.won.length);
    }
    
    public void HasLost()
    {
        Destroy(gameStatsProgressGameObject);
        Invoke("LoadLose", playerStatsScript.death.length);
    }

    public void LoadMenu() // Function to load Scene
    {
        sceneLoader.LoadSceneAsyncByIndex(0);
    }

    public void LoadLightForest() // Function to load Scene
    {
        sceneLoader.LoadSceneAsyncByIndex(1);
    }

    public void LoadDarkForest() // Function to load Scene
    {
        sceneLoader.LoadSceneAsyncByIndex(2);
    }

    public void LoadDungeon() // Function to load Scene
    {
        sceneLoader.LoadSceneAsyncByIndex(3);
    }

    public void LoadLose() // Function to load Scene
    {
        sceneLoader.LoadSceneAsyncByIndex(4);
    }

    public void LoadWin() // Function to load Scene
    {
        sceneLoader.LoadSceneAsyncByIndex(5);
    }
}
