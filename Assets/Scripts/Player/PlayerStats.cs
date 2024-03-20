using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Variables
    [Header("Player Statistics")]
    public int health;
    public int attackDamage;
    public int keys;
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
    public AudioClip hit;
    public AudioClip walk;
    public AudioClip idle;
    public AudioClip won;
    public AudioClip key;
    public AudioClip message;
    [Header("Player Sounds")]
    public AudioSource soundGame;

    // Start is called before the first frame update
    void Start()
    {
        soundGame = GameObject.Find("Sound Manager").transform.Find("Sound Game").GetComponent<AudioSource>();
        health = 100;
        attackDamage = 3;
        keys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        CheckPlayerStatus();
    }

    // Functions
    private void CheckPlayerStatus()
    {
        if (health <= 0)
        {
            isDead = true;
        }
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
                    soundGame.PlayOneShot(hurt);
                }
                else if (health <= 0)
                {
                    isDead = true;
                    soundGame.PlayOneShot(death);
                    Debug.Log("Player was hurt by an enemy to death...");
                    gameObject.SetActive(false);
                    //Invoke("LoadLose", death.length);
                }
            }
        }
        
        if (other.gameObject.tag == "Lava")
        {
            if (health > 0)
            {
                health -= 5;
                soundGame.PlayOneShot(hurt);
            }
            else if (health <= 0)
            {
                isDead = true;
                soundGame.PlayOneShot(death);
                Debug.Log("Player was melted to death...");
                gameObject.SetActive(false);
                //Invoke("LoadLose", death.length);
            }
        }

        if (other.gameObject.tag == "Barrier")
        {
            soundGame.PlayOneShot(message);
            // Show message
            Debug.Log("Player has collided with a barrier!");
            //other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Key")
        {
            soundGame.PlayOneShot(key);
            keys++;
            Debug.Log("Player collected a key!");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Grail")
        {
            playerWon = true;
            soundGame.PlayOneShot(won);
            Debug.Log("Player retrieved the holy grail and finished the level!");
            //other.gameObject.SetActive(false);
            //Invoke("LoadWin", won.length);
        }
    }

    // Triggers
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
