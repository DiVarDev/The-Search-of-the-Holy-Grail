using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Variables
    [Header("Statistics")]
    public float maxHealth = 100.0f;
    public float health;
    public float attackDamage = 3;
    public int keys = 0;
    public bool isGrounded = false;
    public bool isHurt = false;
    public bool isDead = false;
    public bool isAttacking = false;
    public bool hasLost = false;
    public bool hasWon = false;
    [Header("Animator")]
    public Animator animator;
    [Header("Audio Source")]
    public AudioSource audioSource;
    [Header("Sounds")]
    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip attack;
    public AudioClip walk;
    public AudioClip idle;
    public AudioClip won;
    public AudioClip key;
    public AudioClip message;
    [Header("Child GameObjects")]
    public GameObject light2DGameObject;
    public GameObject swordGameObject;

    [Header("Game Manager GameObject")]
    public GameObject gameManagerGameObject;
    public GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerGameObject = GameObject.Find("Game Manager").gameObject;
        gameManagerScript = gameManagerGameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Functions

    // Collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            isGrounded = true;
            Debug.Log("Player touching ground or a platform!");
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (transform.GetComponent<PolygonCollider2D>().IsTouching(other.collider))
            {
                if (health > 0)
                {
                    health -= other.gameObject.GetComponent<EnemyStats>().attackDamage;
                    gameManagerScript.soundManagerAudioSource.PlayOneShot(hurt);
                    Debug.Log("Player is taking damage...");
                }
                else if (health <= 0)
                {
                    isDead = true;    // Set the player died
                    gameManagerScript.soundManagerScript.StopMusic(); // Stop the music audio source from playing music
                    gameManagerScript.soundManagerAudioSource.PlayOneShot(death);   // Play the death sound on the audio source
                                                                                    // referenced in the SoundManager script
                    Debug.Log("Player was hurt by an enemy to death...");
                    gameManagerScript.playerGameObject.SetActive(false);
                    gameManagerScript.HasLost();
                }
            }
        }

        if (other.gameObject.tag == "Lava")
        {
            isDead = true;
            gameManagerScript.soundManagerScript.StopMusic();
            gameManagerScript.soundManagerAudioSource.PlayOneShot(death);
            Debug.Log("Player was melted to death...");
            gameManagerScript.playerGameObject.SetActive(false);
            gameManagerScript.HasLost();
        }

        if (other.gameObject.tag == "Barrier")
        {
            gameManagerScript.soundManagerAudioSource.PlayOneShot(message);
            // Show message
            Debug.Log("Player has collided with a barrier!");
            //other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Key")
        {
            gameManagerScript.soundManagerAudioSource.PlayOneShot(key);
            keys++;
            Debug.Log("Player collected a key!");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Grail")
        {
            hasWon = true;
            gameManagerScript.soundManagerScript.StopMusic();
            gameManagerScript.soundManagerAudioSource.PlayOneShot(won);
            Debug.Log("Player retrieved the holy grail and finished the level!");
            gameManagerScript.playerGameObject.SetActive(false);
            gameManagerScript.HasWon();
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

            switch (gameManagerScript.soundManagerScript.sceneIndex + 1)
            {
                case 1:
                    gameManagerScript.LoadLightForest();
                    break;
                case 2:
                    gameManagerScript.LoadDarkForest();
                    break;
                case 3:
                    gameManagerScript.LoadDungeon();
                    break;
                default:
                    gameManagerScript.LoadMenu();
                    break;
            }

        }
    }

    // Coroutines
}
