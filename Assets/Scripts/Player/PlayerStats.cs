using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Variables
    [Header("Player Statistics")]
    public int maxHealth = 100;
    public int health;
    public int attackDamage = 3;
    public int keys = 0;
    public bool isHurt = false;
    public bool isDead = false;
    public bool isAttacking = false;
    public bool isLookingLeft = false;
    public bool isLookingRight = false;
    public bool isWalking = false;
    public bool isIdle = false;
    public bool playerWon = false;
    [Header("Player Components")]
    public GameObject sword;
    [Header("Player Animations")]
    public Animator animator;
    [Header("Player Sounds")]
    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip attack;
    public AudioClip walk;
    public AudioClip idle;
    public AudioClip won;
    public AudioClip key;
    public AudioClip message;
    [Header("Sound")]
    public AudioSource audioSource;
    public AudioSource soundGame;
    public GameObject soundManager;
    [Header("Scene Loader Script")]
    public SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        soundGame = GameObject.Find("Sound Manager").transform.Find("Sound Game").GetComponent<AudioSource>();
        soundManager = GameObject.Find("Sound Manager").gameObject;

        sceneLoader = gameObject.AddComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        isLookingLeft = animator.GetBool("isLookingLeft");
        isLookingRight = animator.GetBool("isLookingRight");
        isIdle = gameObject.GetComponent<PlayerMovement>().isIdle;

        CheckPlayerStatus();
    }

    // Functions
    private void CheckPlayerStatus()
    {
        if (health <= 0 || isDead)
        {
            isDead = true;
            soundManager.GetComponent<SoundManager>().playMusic = false;
            soundManager.GetComponent<AudioSource>().Stop();
            soundGame.PlayOneShot(death);
            Debug.Log("Player was hurt by an enemy to death...");
            gameObject.SetActive(false);
            Invoke("LoadLose", death.length);
        }
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
        Destroy(GameObject.Find("Game Manager"));
        Destroy(GameObject.Find("Sound Manager"));
        sceneLoader.LoadSceneAsyncByIndex(4);
    }

    public void LoadWin() // Function to load Scene
    {
        Destroy(GameObject.Find("Game Manager"));
        Destroy(GameObject.Find("Sound Manager"));
        sceneLoader.LoadSceneAsyncByIndex(5);
    }

    // Collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (transform.GetComponent<PolygonCollider2D>().IsTouching(other.collider))
            {
                if (health > 0)
                {
                    health -= other.gameObject.GetComponent<EnemyStats>().attackDamage;
                    audioSource.PlayOneShot(hurt);
                    Debug.Log("Player is taking damage...");
                }
            }
        }
        
        if (other.gameObject.tag == "Lava")
        {
            isDead = true;
            soundManager.GetComponent<SoundManager>().playMusic = false;
            soundManager.GetComponent<AudioSource>().Stop();
            soundGame.PlayOneShot(death);
            Debug.Log("Player was melted to death...");
            gameObject.SetActive(false);
            Invoke("LoadLose", death.length);
        }

        if (other.gameObject.tag == "Barrier")
        {
            audioSource.PlayOneShot(message);
            // Show message
            Debug.Log("Player has collided with a barrier!");
            //other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Key")
        {
            audioSource.PlayOneShot(key);
            keys++;
            Debug.Log("Player collected a key!");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Grail")
        {
            playerWon = true;
            soundManager.GetComponent<SoundManager>().playMusic = false;
            soundManager.GetComponent<AudioSource>().Stop();
            audioSource.PlayOneShot(won);
            Debug.Log("Player retrieved the holy grail and finished the level!");
            //other.gameObject.SetActive(false);
            Invoke("LoadWin", won.length);
        }
    }

    // Triggers
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Teleport")
        {
            //audioSource.PlayOneShot(won);
            Debug.Log("Player retrieved the holy grail and finished the level!");
            //other.gameObject.SetActive(false);
            Invoke("LoadDarkForest", 0.0f);
            
        }
    }

    // Coroutines
}
