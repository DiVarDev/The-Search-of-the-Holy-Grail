using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public bool isObjectDestroyOnLoad;
    [Header("Player Info")]
    public GameObject player;
    public bool isPlayerDead;
    public int health;
    public int keys;
    [Header("User Interface Components")]
    public Slider healthSlider;
    public TMP_Text keysText;
    public TMP_Text timerText;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        if (!isObjectDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GameObject.Find("Player");
        isPlayerDead = player.GetComponent<PlayerStats>().isDead;
        keys = 0;

        healthSlider = GameObject.Find("Canvas").transform.Find("Health Slider").GetComponent<Slider>();
        healthSlider.maxValue = player.GetComponent<PlayerStats>().maxHealth;
        keysText = GameObject.Find("Canvas").transform.Find("Player Keys Text").GetComponent<TMP_Text>();

        timerText = GameObject.Find("Canvas").transform.Find("Player Timer Text").GetComponent<TMP_Text>();
        time = 145.0f;
        StartCoroutine(IniciarCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerStats>().health;
        healthSlider.value = player.GetComponent<PlayerStats>().health;
        keys = player.GetComponent<PlayerStats>().keys;
        keysText.text = keys.ToString();
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
        player.GetComponent<PlayerStats>().isDead = true;
        Debug.Log("Player has run out of time...");
        gameObject.SetActive(false);
        Invoke("LoadLose", player.GetComponent<PlayerStats>().death.length);
    }

    // Functions

}
